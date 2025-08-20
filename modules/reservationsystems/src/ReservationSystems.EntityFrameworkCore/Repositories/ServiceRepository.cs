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
    public class ServiceRepository : EfCoreRepository<ReservationSystemsDbContext, Services, Guid>, IServicesRepository
    {
        public ServiceRepository(IDbContextProvider<ReservationSystemsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
