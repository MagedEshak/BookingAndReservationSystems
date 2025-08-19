using Abp.Application.Services.Dto;
using ReservationSystems.Dtos.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.IAppServices
{
    public interface ILocationAppService
    {
        Task<LocationsDto> GetLocationByIdAsync(Guid id);
        Task<PagedResultDto<LocationsDto>> GetAllLocationsAsync(PagedAndSortedResultRequestDto input);
        Task<LocationsDto> CreateLocationAsync(CreateLocationDto createLocationDto);
        Task<LocationsDto> UpdateLocationAsync(Guid id, UpdateLocationDto updateLocationDto);
        Task<bool> DeleteLocationAsync(Guid id);
    }
}
