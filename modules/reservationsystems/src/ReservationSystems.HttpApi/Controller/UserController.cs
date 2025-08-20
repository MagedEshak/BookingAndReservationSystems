using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationSystems.Dtos.User;
using ReservationSystems.IAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ReservationSystems.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ReservationSystemsController
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpGet("AllUsers")]
        public async Task<PagedResultDto<UserWithNavigtionProperty>> GetAllUsers([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return await _userAppService.GetAllUsersAsync(input);
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<UserDto> GetUserById(Guid id)
        {
            return await _userAppService.GetUserByIdAsync(id);
        }
        [HttpGet("GetUserWithHisBookingsById/{id}")]
        public async Task<UserDto> GetUserWithHisBookingsById(Guid id)
        {
            return await _userAppService.GetUserWithHisBookingsByIdAsync(id);
        }
        [HttpGet("GetUserWithHisReviewsById/{id}")]
        public async Task<UserDto> GetUserWithHisReviewsById(Guid id)
        {
            return await _userAppService.GetUserWithHisReviewsByIdAsync(id);
        }
        [HttpGet("check-Email")]
        public async Task<bool> CheckEmail(string email)
        {
            return await _userAppService.CheckEmailAsync(email);
        }
        [HttpGet("check-Phone")]
        public async Task<bool> CheckPhone(string phone)
        {
            return await _userAppService.CheckPhoneAsync(phone);
        }
        [HttpPost]
        public async Task<UserDto> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            return await _userAppService.CreateUserAsync(createUserDto);
        }
        [HttpPatch("{id}")]
        public async Task<UserDto> UpdateUser(Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            return await _userAppService.UpdateUserAsync(id, updateUserDto);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteUser(Guid id)
        {
            return await _userAppService.DeleteUserAsync(id);
        }
    }
}
