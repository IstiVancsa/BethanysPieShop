using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Shared.Services
{
    public class ReviewDataService : IReviewDataService
    {
        private readonly HttpClient _httpClient;
        public ReviewDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddReviewAsync(Review Review)
        {
            var uri = new Uri(string.Format(this._httpClient.BaseAddress + "Review/AddReview"));
            try
            {

                //this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(this.Token);
                var serializedUser = JsonConvert.SerializeObject(Review);
                var data = new StringContent(serializedUser, Encoding.UTF8, "application/json");
                var response = await this._httpClient.PostAsync(uri, data);
                return response.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                var dsad = ex.Message;
                return false;
            }
        }

        public Task<bool> DeleteReviewAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Review> GetReviewAsync(Guid id)
        {
            return (await this.ReturnGetHttp<List<Review>>(this._httpClient.BaseAddress + "Review/GetByFilter/?Id=" + id)).FirstOrDefault();
        }

        public async Task<IList<Review>> GetReviewsAsync()
        {
            return await this.ReturnGetHttp<List<Review>>(this._httpClient.BaseAddress + "Review/GetDefault/");
        }

        public Task<IList<Review>> GetReviewsAsync(string filters)
        {
            throw new NotImplementedException();
        }

        public async Task<TResult> ReturnGetHttp<TResult>(string url)
        {
            TResult items = default(TResult);

            var uri = new Uri(string.Format(url));
            try
            {

                //this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(this.Token);
                var response = await this._httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<TResult>(content);
                }
            }
            catch (Exception ex)
            {
                var dsad = ex.Message;
            }

            return items;
        }

        public Task<bool> UpdateReviewAsync(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
