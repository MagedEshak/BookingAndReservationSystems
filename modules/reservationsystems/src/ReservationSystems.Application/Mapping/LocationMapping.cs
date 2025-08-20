using AutoMapper;
using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.Location;
using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Mapping
{
    public class LocationMapping : Profile
    {
        public LocationMapping()
        {
            CreateMap<Locations, LocationsDto>()
                    .ForMember(b => b.ServicesDtos, otp => otp.MapFrom(src => src.Services));
            CreateMap<CreateLocationDto, Locations>()
                .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                .ForMember(b => b.Services, otp => otp.Ignore())
                .ForMember(b => b.TenantId, otp => otp.Ignore())
                .ForMember(b => b.IsDeleted, otp => otp.Ignore())
                .ForMember(b => b.Id, otp => otp.Ignore());
            CreateMap<UpdateLocationDto, Locations>()
                .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                .ForMember(b => b.Id, otp => otp.Ignore())
                .ForMember(b => b.Services, otp => otp.Ignore())
                .ForMember(b => b.Name, otp => otp.Ignore())
                .ForMember(b => b.City, otp => otp.Ignore())
                .ForMember(b => b.Country, otp => otp.Ignore())
                .ForMember(b => b.Address, otp => otp.Ignore())
                .ForMember(b => b.TenantId, otp => otp.Ignore())
                .ForMember(b => b.IsDeleted, otp => otp.Ignore());
        }
    }
}
