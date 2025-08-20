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
        public async Task<PagedResultDto<UserWithNavigtionProperty>> GetAllUsers(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<UserDto> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetUserWithHisBookingsById/{id}")]
        public async Task<UserDto> GetUserWithHisBookingsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetUserWithHisReviewsById/{id}")]
        public async Task<UserDto> GetUserWithHisReviewsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("check-Email")]
        public async Task<bool> CheckEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
        [HttpGet("check-Phone")]
        public async Task<bool> CheckPhoneAsync(string phone)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }
        [HttpPatch("{id}")]
        public async Task<UserDto> UpdateUserAsync(Guid id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
