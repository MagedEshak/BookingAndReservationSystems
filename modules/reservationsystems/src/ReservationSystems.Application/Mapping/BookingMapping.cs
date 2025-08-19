using AutoMapper;
using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.User;
using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
            CreateMap<Bookings, BookingDto>();
            CreateMap<CreateUserDto, Bookings>()
                .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                .ForMember(b => b.Bookings, otp => otp.Ignore())
                .ForMember(b => b.TenantId, otp => otp.Ignore())
                .ForMember(b => b.IsDeleted, otp => otp.Ignore())
                .ForMember(b => b.ExtraProperties, otp => otp.Ignore())
                .IgnoreCreationAuditedObjectProperties().IgnoreAuditedObjectProperties();
            CreateMap<UpdateUserDto, User>()
                .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                .ForMember(b => b.Bookings, otp => otp.Ignore())
                .ForMember(b => b.TenantId, otp => otp.Ignore())
                .ForMember(b => b.IsDeleted, otp => otp.Ignore())
                .ForMember(b => b.ExtraProperties, otp => otp.Ignore())
                .IgnoreCreationAuditedObjectProperties().IgnoreAuditedObjectProperties();
        }
    }
}
