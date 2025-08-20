using ReservationSystems.Dtos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ReservationSystems.IAppServices
{
    public interface IServicesAppService
    {
        Task<PagedResultDto<ServicesWithNavigtionProperty>> GetAllServicesAsync(PagedAndSortedResultRequestDto input);
        Task<ServicesDto> GetServiceByIdAsync(Guid id);
        Task<ServicesDto> CreateServiceAsync(CreateServiceDto createServicesDto);
        Task<ServicesDto> UpdateServiceAsync(Guid id, UpdateServiceDto updateServicesDto);
        Task<bool> DeleteServiceAsync(Guid id);
    }
}
