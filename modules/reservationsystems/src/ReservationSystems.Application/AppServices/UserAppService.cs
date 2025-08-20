using Abp.Domain.Uow;
using Castle.MicroKernel.Internal;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;
using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.Reviews;
using ReservationSystems.Dtos.User;
using ReservationSystems.IAppServices;
using ReservationSystems.IRepositories;
using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using System.Linq.Dynamic.Core;

namespace ReservationSystems.EntityFrameworkCore
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Asynchronously checks whether the specified email address exists in the user repository.
        /// </summary>
        /// <param name="email">The email address to check. Cannot be null or empty.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is  <see langword="true"/> if the email
        /// address exists; otherwise, <see langword="false"/>.</returns> 
        public async Task<bool> CheckEmailAsync(string email)
        {
            return await _userRepository.CheckEmailAsync(email);
        }
        /// <summary>
        /// Asynchronously checks whether a phone number exists in the user repository.
        /// </summary>
        /// <param name="phone">The phone number to check. Cannot be null or empty.</param>
        /// <returns><see langword="true"/> if the phone number exists in the repository; otherwise, <see langword="false"/>.</returns> 
        public async Task<bool> CheckPhoneAsync(string phone)
        {
            return await _userRepository.CheckPhoneAsync(phone);
        }
        /// <summary>
        /// Creates a new user based on the provided user details.
        /// </summary>
        /// <remarks>This method maps the provided <see cref="CreateUserDto"/> to a user entity, inserts
        /// it into the repository, and returns the created user as a <see cref="UserDto"/>. The operation is performed
        /// asynchronously.</remarks>
        /// <param name="createUserDto">The data transfer object containing the details of the user to be created.</param>
        /// <returns>A <see cref="UserDto"/> representing the newly created user.</returns> 
        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            try
            {
                var user = ObjectMapper.Map<CreateUserDto, User>(createUserDto);
                var insertedUser = await _userRepository.InsertAsync(user, autoSave: true);
                return ObjectMapper.Map<User, UserDto>(insertedUser);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Create User");
                throw;
            }
        }
        /// <summary>
        /// Deletes a user with the specified identifier asynchronously.
        /// </summary>
        /// <remarks>This method logs any exceptions that occur during the deletion process and rethrows
        /// them.</remarks>
        /// <param name="id">The unique identifier of the user to delete.</param>
        /// <returns><see langword="true"/> if the user was successfully deleted; otherwise, <see langword="false"/>.</returns> 
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.FindAsync(id);
                if (user == null)
                {
                    throw new EntityNotFoundException(typeof(UserDto), id);
                }
                await _userRepository.DeleteAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Delete User");
                throw;
            }
        }
        /// <summary>
        /// Retrieves a paginated and sorted list of users, including their associated bookings and services.
        /// </summary>
        /// <remarks>This method retrieves users from the repository and includes their related bookings
        /// and services.  If no sorting is specified, the users are sorted by their <see cref="User.Id"/> property by
        /// default.</remarks>
        /// <param name="input">The pagination and sorting parameters.  <see cref="PagedAndSortedResultRequestDto.SkipCount"/> specifies the
        /// number of items to skip,  <see cref="PagedAndSortedResultRequestDto.MaxResultCount"/> specifies the maximum
        /// number of items to return,  and <see cref="PagedAndSortedResultRequestDto.Sorting"/> specifies the sorting
        /// criteria.</param>
        /// <returns>A <see cref="PagedResultDto{T}"/> containing the total count of users and a list of users with their
        /// associated bookings and services.</returns> 
        public async Task<PagedResultDto<UserWithNavigtionProperty>> GetAllUsersAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                if (input.Sorting.IsNullOrWhiteSpace())
                {
                    input.Sorting = nameof(User.Id);
                }
                var query = (await _userRepository.GetQueryableAsync())
                    .Include(b => b.Bookings)
                    .ThenInclude(b => b.Services);
                var totalCount = await _userRepository.GetCountAsync();
                var items = await query
                     .OrderBy(input.Sorting)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
                     .ToListAsync();
                var result = items.Select(user => new UserWithNavigtionProperty
                {
                    UserDtos = ObjectMapper.Map<User, UserDto>(user),
                    BookingDtos = user.Bookings != null ?
                                        ObjectMapper.Map<List<Bookings>, List<BookingDto>>(user.Bookings.ToList())
                : new List<BookingDto>()
                }).ToList();
                return new PagedResultDto<UserWithNavigtionProperty>(totalCount, result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Get All Users");
                throw;
            }
        }
        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <remarks>This method retrieves a user from the underlying data source and maps the result to a
        /// <see cref="UserDto"/>. Ensure that the provided <paramref name="id"/> is valid and corresponds to an
        /// existing user.</remarks>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>A <see cref="UserDto"/> representing the user with the specified identifier.</returns> 
        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetAsync(id);
                if (user == null)
                {
                    throw new EntityNotFoundException(typeof(UserDto), id);
                }
                return ObjectMapper.Map<User, UserDto>(user);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Get User By ID");
                throw;
            }
        }
        /// <summary>
        /// Retrieves a user and their associated bookings by the specified user ID.
        /// </summary>
        /// <remarks>This method retrieves the user and their bookings from the data source, maps them to
        /// DTOs,  and returns the result. If the user has no bookings, the <c>BookingDtos</c> property of the  returned
        /// <see cref="UserDto"/> will be initialized as an empty list.</remarks>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>A <see cref="UserDto"/> object containing the user's details and their associated bookings. If the user has
        /// no bookings, the <c>BookingDtos</c> property will be an empty list.</returns> 
        public async Task<UserDto> GetUserWithHisBookingsByIdAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetUserWithBookingAsync(id);
                if (user == null)
                {
                    throw new EntityNotFoundException(typeof(User), id);
                }
                var userDto = ObjectMapper.Map<User, UserDto>(user);
                userDto.BookingDtos = user.Bookings != null
                                 ? ObjectMapper.Map<List<Bookings>, List<BookingDto>>(user.Bookings.ToList())
                                 : new List<BookingDto>();
                return userDto;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Get User By ID");
                throw;
            }
        }
        /// <summary>
        /// Retrieves a user and their associated reviews by the specified user ID.
        /// </summary>
        /// <remarks>This method retrieves the user and their reviews from the data source, maps them to
        /// DTOs, and returns the result. The method ensures that the returned <c>ReviewsDtos</c> property is never
        /// <c>null</c>.</remarks>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>A <see cref="UserDto"/> object containing the user's details and their associated reviews. If the user has
        /// no reviews, the <c>ReviewsDtos</c> property will be an empty list.</returns> 
        public async Task<UserDto> GetUserWithHisReviewsByIdAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetUserWithReviewsAsync(id);
                if (user == null)
                {
                    throw new EntityNotFoundException(typeof(User), id);
                }
                var userDto = ObjectMapper.Map<User, UserDto>(user);
                userDto.ReviewsDtos = user.Reviews != null
                    ? ObjectMapper.Map<List<Reviews>, List<ReviewsDto>>(user.Reviews.ToList())
                    : new List<ReviewsDto>();
                return userDto;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Get User By ID");
                throw;
            }
        }
        /// <summary>
        /// Updates an existing user with the specified changes.
        /// </summary>
        /// <remarks>This method retrieves the user by the specified <paramref name="id"/> and applies the
        /// changes  provided in the <paramref name="updateUserDto"/>. If the user does not exist, an  <see
        /// cref="EntityNotFoundException"/> is thrown. If the concurrency stamp does not match, an  <see
        /// cref="AbpDbConcurrencyException"/> is thrown to indicate that the record has been modified  by another
        /// process.</remarks>
        /// <param name="id">The unique identifier of the user to update.</param>
        /// <param name="updateUserDto">An object containing the updated user information. This includes optional fields such as  name, email,
        /// phone, bookings, and reviews. The <see cref="UpdateUserDto.ConcurrencyStamp"/>  must match the current
        /// concurrency stamp of the user to ensure data consistency.</param>
        /// <returns>A <see cref="UserDto"/> object representing the updated user.</returns>
        /// <exception cref="EntityNotFoundException">Thrown if no user with the specified <paramref name="id"/> is found.</exception>
        /// <exception cref="AbpDbConcurrencyException">Thrown if the <see cref="UpdateUserDto.ConcurrencyStamp"/> does not match the current concurrency  stamp of
        /// the user.</exception>
        public async Task<UserDto> UpdateUserAsync(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                throw new EntityNotFoundException("This User Not Found");
            }
            if (string.IsNullOrWhiteSpace(updateUserDto.ConcurrencyStamp) || updateUserDto.ConcurrencyStamp != user.ConcurrencyStamp)
            {
                throw new AbpDbConcurrencyException("The record has been modified by someone else.");
            }
            if (updateUserDto.Name != null)
            {
                user.Name = updateUserDto.Name;
            }
            if (updateUserDto.Email != null)
            {
                user.Email = updateUserDto.Email;
            }
            if (updateUserDto.Phone != null)
            {
                user.Phone = updateUserDto.Phone;
            }
            if (updateUserDto.BookingDtos != null)
            {
                user.Bookings = updateUserDto.BookingDtos
                    .Select(dto => ObjectMapper.Map<BookingDto, Bookings>(dto))
                    .ToList();
            }
            if (updateUserDto.ReviewsDtos != null)
            {
                user.Reviews = updateUserDto.ReviewsDtos
                    .Select(dto => ObjectMapper.Map<ReviewsDto, Reviews>(dto))
                    .ToList();
            }
            await _userRepository.UpdateAsync(user, autoSave: true);
            return ObjectMapper.Map<User, UserDto>(user);
        }
    }
}
