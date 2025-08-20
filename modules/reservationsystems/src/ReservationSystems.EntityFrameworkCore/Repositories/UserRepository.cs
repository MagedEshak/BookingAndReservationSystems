using ReservationSystems.EntityFrameworkCore;
using ReservationSystems.IRepositories;
using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ReservationSystems.Repositories
{
    public class UserRepository : EfCoreRepository<ReservationSystemsDbContext, User, Guid>, IUserRepository
    {
        public UserRepository(IDbContextProvider<ReservationSystemsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
        public async Task<bool> CheckEmailAsync(string email)
        {
            var db = await GetDbContextAsync();
            return await db.User.AnyAsync(u => u.Email == email);
        }
        public async Task<bool> CheckPhoneAsync(string phone)
        {
            var db = await GetDbContextAsync();
            return await db.User.AnyAsync(u => u.Phone == phone);
        }
        public async Task<User> GetUserWithBookingAsync(Guid id)
        {
            var db = await GetDbContextAsync();
            return await db.User.Include(b => b.Bookings).ThenInclude(s=>s.Services)
                                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User> GetUserWithReviewsAsync(Guid id)
        {
            var db = await GetDbContextAsync();
            return await db.User.Include(b => b.Reviews).ThenInclude(s => s.Services)
                                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
