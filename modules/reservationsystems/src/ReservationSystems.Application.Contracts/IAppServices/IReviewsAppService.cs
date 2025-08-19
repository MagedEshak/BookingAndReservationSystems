using Abp.Application.Services.Dto;
using ReservationSystems.Dtos.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystems.IAppServices
{

    public interface IReviewsAppService
    {
        Task<ReviewsDto> GetReviewByIdAsync(Guid id);
        Task<PagedResultDto<ReviewsWithNavigationProperty>> GetAllReviewsAsync(PagedAndSortedResultRequestDto input);
        Task<ReviewsDto> CreateReviewAsync(CreateReviewDto createReviewDto);
        Task<ReviewsDto> UpdateReviewAsync(Guid id, UpdateReviewDto updateReviewDto);
        Task<bool> DeleteReviewAsync(Guid id);
    }
}
