using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ReservationSystems.IRepositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetUserWithBookingAsync(Guid id);
        Task<User> GetUserWithReviewsAsync(Guid id);
        Task<bool> CheckEmailAsync(string email);
        Task<bool> CheckPhoneAsync(string phone);
    }
}
