using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationSystems.Dtos.Services;
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
    public class ServicesController : ReservationSystemsController
    {
        private readonly IServicesAppService _servicesAppService;

        public ServicesController(IServicesAppService servicesAppService)
        {
            _servicesAppService = servicesAppService;
        }
        [HttpGet("GetAll")]
        public async Task<PagedResultDto<ServicesWithNavigtionProperty>> GetAllServices([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return await _servicesAppService.GetAllServicesAsync(input);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ServicesDto> GetServiceById(Guid id)
        {
            return await _servicesAppService.GetServiceByIdAsync(id);
        }
        [HttpPost("Create")]
        public async Task<ServicesDto> CreateService([FromBody] CreateServiceDto createServicesDto)
        {
            return await _servicesAppService.CreateServiceAsync(createServicesDto);
        }

        [HttpPut("Update/{id}")]
        public async Task<ServicesDto> UpdateService(Guid id, [FromBody] UpdateServiceDto updateServicesDto)
        {
            return await _servicesAppService.UpdateServiceAsync(id, updateServicesDto);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<bool> DeleteService(Guid id)
        {
            return await _servicesAppService.DeleteServiceAsync(id);
        }
    }
}
