using AutoMapper;
using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.User;
using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;

namespace ReservationSystems.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<Bookings, BookingDto>();
            CreateMap<CreateBookingDto, Bookings>()
                .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                .ForMember(b => b.Services, otp => otp.Ignore())
                .ForMember(b => b.Users, otp => otp.Ignore())
                .ForMember(b => b.TenantId, otp => otp.Ignore())
                .ForMember(b => b.IsDeleted, otp => otp.Ignore())
                 .ForMember(b => b.DeleterId, otp => otp.Ignore())
                .ForMember(b => b.CreationTime, otp => otp.Ignore())
                .ForMember(b => b.LastModificationTime, otp => otp.Ignore())
                .ForMember(b => b.CreatorId, otp => otp.Ignore())
                .ForMember(b => b.LastModifierId, otp => otp.Ignore())
                .ForMember(b => b.DeletionTime, otp => otp.Ignore())
                .ForMember(b => b.Id, otp => otp.Ignore());

            CreateMap<UpdateBookingDto, Bookings>()
                .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                .ForMember(b => b.Id, otp => otp.Ignore())
                .ForMember(b => b.Services, otp => otp.Ignore())
                .ForMember(b => b.Users, otp => otp.Ignore())
                .ForMember(b => b.TenantId, otp => otp.Ignore())
                .ForMember(b => b.IsDeleted, otp => otp.Ignore())
                .ForMember(b => b.DeleterId, otp => otp.Ignore())
                .ForMember(b => b.CreationTime, otp => otp.Ignore())
                .ForMember(b => b.LastModificationTime, otp => otp.Ignore())
                .ForMember(b => b.CreatorId, otp => otp.Ignore())
                .ForMember(b => b.LastModifierId, otp => otp.Ignore())
                .ForMember(b => b.DeletionTime, otp => otp.Ignore());
        }
    }
}
