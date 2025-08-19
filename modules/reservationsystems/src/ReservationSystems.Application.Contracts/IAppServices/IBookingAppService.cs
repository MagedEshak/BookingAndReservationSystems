using Abp.Application.Services.Dto;
using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.IAppServices
{
    public interface IBookingAppService
    {
        Task<BookingDto> GetBookingByIdAsync(Guid id);
        Task<PagedResultDto<BookingDto>> GetAllBookigAsync(PagedAndSortedResultRequestDto input);
        Task<UserDto> CreateBookingAsync(CreateBookingDto createBookingDto);
        Task<UserDto> UpdateBookingAsync(Guid id, UpdateBookingDto updateBookingDto);
        Task<bool> DeleteBookingAsync(Guid id);
    }
}
