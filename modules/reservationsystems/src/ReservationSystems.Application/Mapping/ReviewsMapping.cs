using AutoMapper;
using ReservationSystems.Dtos.Booking;
using ReservationSystems.Dtos.Reviews;
using ReservationSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.Mapping
{
    public class ReviewsMapping:Profile
    {
        public ReviewsMapping()
        {
            CreateMap<Reviews, ReviewsDto>();
            CreateMap<CreateReviewDto, Reviews>()
                .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                .ForMember(b => b.Services, otp => otp.Ignore())
                .ForMember(b => b.Users, otp => otp.Ignore())
                .ForMember(b => b.Id, otp => otp.Ignore())
                .ForMember(b => b.TenantId, otp => otp.Ignore())
                .ForMember(b => b.IsDeleted, otp => otp.Ignore());

            CreateMap<UpdateReviewDto, Reviews>()
                .ForMember(b => b.ConcurrencyStamp, otp => otp.Ignore())
                .ForMember(b => b.Id, otp => otp.Ignore())
                .ForMember(b => b.Services, otp => otp.Ignore())
                .ForMember(b => b.Users, otp => otp.Ignore())
                .ForMember(b => b.TenantId, otp => otp.Ignore())
                .ForMember(b => b.IsDeleted, otp => otp.Ignore());
        }
    }
}
