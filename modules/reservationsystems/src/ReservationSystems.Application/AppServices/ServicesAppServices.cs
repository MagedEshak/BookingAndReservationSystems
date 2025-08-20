using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.Location;
using ReservationSystems.Dtos.Reviews;
using ReservationSystems.Dtos.Services;
using ReservationSystems.IAppServices;
using ReservationSystems.IRepositories;
using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;


namespace ReservationSystems.AppServices
{
    public class ServicesAppServices : ApplicationService, IServicesAppService
    {
        private readonly IServicesRepository _servicesRepository;

        public ServicesAppServices(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }
        public async Task<ServicesDto> CreateServiceAsync(CreateServiceDto createServicesDto)
        {
            try
            {
                var services = ObjectMapper.Map<CreateServiceDto, Services>(createServicesDto);
                var insertedServices = await _servicesRepository.InsertAsync(services, autoSave: true);
                return ObjectMapper.Map<Services, ServicesDto>(insertedServices);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Create User");
                throw;
            }
        }

        public async Task<bool> DeleteServiceAsync(Guid id)
        {
            try
            {
                var service = await _servicesRepository.FindAsync(id);
                if (service == null)
                {
                    throw new EntityNotFoundException(typeof(ServicesDto), id);
                }
                await _servicesRepository.DeleteAsync(service);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Delete Service");
                throw;
            }
        }

        public async Task<PagedResultDto<ServicesWithNavigtionProperty>> GetAllServicesAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                if (input.Sorting.IsNullOrWhiteSpace())
                {
                    input.Sorting = nameof(Services.Id);
                }
                var query = (await _servicesRepository.GetQueryableAsync())
                    .Include(l=>l.Locations);

                var totalCount = await _servicesRepository.GetCountAsync();
                var items = await query
                     .OrderBy(input.Sorting)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
                     .ToListAsync();
                var result = items.Select(service => new ServicesWithNavigtionProperty
                {
                    ServicesDto = ObjectMapper.Map<Services, ServicesDto>(service),
                    BookingDtos = service.Bookings != null ?
                                        ObjectMapper.Map<List<Bookings>, List<BookingDto>>(service.Bookings.ToList())
                : new List<BookingDto>(),
                    ReviewsDtos = service.Reviews != null ?
                                        ObjectMapper.Map<List<Reviews>, List<ReviewsDto>>(service.Reviews.ToList())
                : new List<ReviewsDto>()
                }).ToList();
                return new PagedResultDto<ServicesWithNavigtionProperty>(totalCount, result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error in Get All Services");
                throw;
            }
        }

        public async Task<ServicesDto> GetServiceByIdAsync(Guid id)
        {
            var service = await _servicesRepository.GetAsync(id, includeDetails: true);
            if (service == null)
            {
                throw new EntityNotFoundException(typeof(Services), id);
            }

            return ObjectMapper.Map<Services, ServicesDto>(service);
        }
        public async Task<ServicesDto> UpdateServiceAsync(Guid id, UpdateServiceDto updateServicesDto)
        {
            var service = await _servicesRepository.GetAsync(id);
            if (service == null)
            {
                throw new EntityNotFoundException(typeof(Services), id);
            }

            // Concurrency check (if you use ConcurrencyStamp like with Users)
            if (string.IsNullOrWhiteSpace(updateServicesDto.ConcurrencyStamp) ||
                updateServicesDto.ConcurrencyStamp != service.ConcurrencyStamp)
            {
                throw new AbpDbConcurrencyException("The record has been modified by someone else.");
            }

            // Update only provided fields
            if (!string.IsNullOrWhiteSpace(updateServicesDto.Name))
                service.Name = updateServicesDto.Name;

            if (!string.IsNullOrWhiteSpace(updateServicesDto.Description))
                service.Description = updateServicesDto.Description;

            if (updateServicesDto.Price.HasValue)
                service.Price = updateServicesDto.Price.Value;

            if (updateServicesDto.LocationID.HasValue)
                service.LocationID = updateServicesDto.LocationID.Value;
            if (updateServicesDto.BookingDtos != null)
            {
                service.Bookings = updateServicesDto.BookingDtos
                    .Select(dto => ObjectMapper.Map<BookingDto, Bookings>(dto))
                    .ToList();
            }
            if (updateServicesDto.ReviewsDtos != null)
            {
                service.Reviews = updateServicesDto.ReviewsDtos
                    .Select(dto => ObjectMapper.Map<ReviewsDto, Reviews>(dto))
                    .ToList();
            }

            await _servicesRepository.UpdateAsync(service, autoSave: true);

            return ObjectMapper.Map<Services, ServicesDto>(service);
        }
    }
}
