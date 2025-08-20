using ReservationSystems.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace ReservationSystems.IAppServices
{
    public interface IUserAppService
    {
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<PagedResultDto<UserWithNavigtionProperty>> GetAllUsersAsync(PagedAndSortedResultRequestDto input);
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> UpdateUserAsync(Guid id,UpdateUserDto createUserDto);
        Task<bool> DeleteUserAsync(Guid id);
        Task<bool> CheckEmailAsync(string email);
        Task<bool> CheckPhoneAsync(string phone);
    }
}
