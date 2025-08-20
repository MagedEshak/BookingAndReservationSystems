using AutoMapper;
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
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>()
                .ForMember(b => b.BookingDtos, otp => otp.MapFrom(src => src.Bookings))
                .ForMember(b => b.ReviewsDtos, otp => otp.MapFrom(src => src.Reviews));
            CreateMap<CreateUserDto, User>()
                .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                .ForMember(b => b.Bookings, otp => otp.Ignore())
                .ForMember(b => b.Reviews, otp => otp.Ignore())
                .ForMember(b => b.TenantId, otp => otp.Ignore())
                .ForMember(b => b.IsDeleted, otp => otp.Ignore())
                .ForMember(b => b.DeleterId, otp => otp.Ignore())
                .ForMember(b => b.CreationTime, otp => otp.Ignore())
                .ForMember(b => b.LastModificationTime, otp => otp.Ignore())
                .ForMember(b => b.CreatorId, otp => otp.Ignore())
                .ForMember(b => b.LastModifierId, otp => otp.Ignore())
                .ForMember(b => b.DeletionTime, otp => otp.Ignore())
                .ForMember(b => b.Id, otp => otp.Ignore())
                .ForMember(b => b.ExtraProperties, otp => otp.Ignore())
                .IgnoreCreationAuditedObjectProperties().IgnoreAuditedObjectProperties();
            CreateMap<UpdateUserDto, User>()
                 .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                .ForMember(b => b.Bookings, otp => otp.Ignore())
                .ForMember(b => b.Reviews, otp => otp.Ignore())
                .ForMember(b => b.TenantId, otp => otp.Ignore())
                .ForMember(b => b.IsDeleted, otp => otp.Ignore())
                .ForMember(b => b.DeleterId, otp => otp.Ignore())
                .ForMember(b => b.CreationTime, otp => otp.Ignore())
                .ForMember(b => b.LastModificationTime, otp => otp.Ignore())
                .ForMember(b => b.CreatorId, otp => otp.Ignore())
                .ForMember(b => b.LastModifierId, otp => otp.Ignore())
                .ForMember(b => b.DeletionTime, otp => otp.Ignore())
                .ForMember(b => b.ExtraProperties, otp => otp.Ignore())
                .IgnoreCreationAuditedObjectProperties().IgnoreAuditedObjectProperties();
        }
    }
}
