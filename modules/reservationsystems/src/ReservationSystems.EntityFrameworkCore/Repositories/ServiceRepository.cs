using ReservationSystems.EntityFrameworkCore;
using ReservationSystems.IRepositories;
using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ReservationSystems.Repositories
{
    public class ServiceRepository:EfCoreRepository<ReservationSystemsDbContext, Services, Guid>, IServicesRepository
    {
        public ServiceRepository(IDbContextProvider<ReservationSystemsDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }
        public async Task<Services> GetServicesWithLocationAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
