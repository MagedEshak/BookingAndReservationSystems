using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ReservationSystems.IRepositories
{
    public interface IServicesRepository:IRepository<Services, Guid>
    {
       
    }
}
