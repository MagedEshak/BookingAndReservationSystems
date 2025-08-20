using AutoMapper;
using ReservationSystems.Dtos.Services;
using ReservationSystems.Dtos.User;
using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Mapping
{
    public class ServicesMapping : Profile
    {
        public ServicesMapping()
        {
            CreateMap<Services, ServicesDto>()
                .ForMember(dest => dest.LocationsCountry, opt => opt.MapFrom(src => src.Locations.Country))
                   .ForMember(d => d.BookingDtos, opt => opt.MapFrom(src => src.Bookings))
                   .ForMember(d => d.ReviewsDtos, opt => opt.MapFrom(src => src.Reviews));
            CreateMap<CreateServiceDto, Services>()
                 .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                 .ForMember(b => b.Bookings, otp => otp.Ignore())
                 .ForMember(b => b.Reviews, otp => otp.Ignore())
                 .ForMember(b => b.Locations, otp => otp.Ignore())
                 .ForMember(b => b.Id, otp => otp.Ignore())
                 .ForMember(b => b.TenantId, otp => otp.Ignore())
                 .ForMember(b => b.IsDeleted, otp => otp.Ignore());
            CreateMap<UpdateServiceDto, Services>()
                 .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                 .ForMember(b => b.Id, otp => otp.Ignore())
                 .ForMember(b => b.Bookings, otp => otp.Ignore())
                 .ForMember(b => b.Reviews, otp => otp.Ignore())
                 .ForMember(b => b.Locations, otp => otp.Ignore())
                 .ForMember(b => b.TenantId, otp => otp.Ignore())
                 .ForMember(b => b.IsDeleted, otp => otp.Ignore());
        }
    }
}
