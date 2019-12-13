using BethanysPieShopHRM.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Shared.IServices
{
    public interface IReviewDataService
    {
        Task<bool> AddReviewAsync(Review Review);
        Task<bool> DeleteReviewAsync(Guid id);
        Task<Review> GetReviewAsync(Guid id);
        Task<IList<Review>> GetReviewsAsync();
        Task<IList<Review>> GetReviewsAsync(string filters);
        Task<bool> UpdateReviewAsync(Review review);
        Task<TResult> ReturnGetHttp<TResult>(string url);
    }
}
