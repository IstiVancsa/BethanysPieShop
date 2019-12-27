using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Shared.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly HttpClient _httpClient;

        public UserDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddUserAsync(User user)
        {

            var uri = new Uri(string.Format(this._httpClient.BaseAddress + "User/AddUser"));
            try
            {

                //this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(this.Token);
                var serializedUser = JsonConvert.SerializeObject(user);
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

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            //bool result = true;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.UrlApi + id);
            //request.Method = "DELETE";
            //request.ContentType = "application/json";

            //var response = (await request.GetResponseAsync()) as HttpWebResponse;
            //result = response.StatusCode == HttpStatusCode.OK;

            //return result;
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return (await this.ReturnGetHttp<List<User>>(this._httpClient.BaseAddress + "User/GetByFilter/?Id=" + id)).FirstOrDefault();
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            return await this.ReturnGetHttp<List<User>>(this._httpClient.BaseAddress + "User/GetDefault/");
        }

        public async Task<IList<User>> GetUsersAsync(string filters)
        {
            //return await this.ReturnGetHttp<List<User>>(this.UrlApi + "GetByFilter/" + filters);
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                var uri = new Uri(string.Format(this._httpClient.BaseAddress + "User/EditUser"));

                var serializedItem = JsonConvert.SerializeObject(user);
                var content = new StringContent(serializedItem, Encoding.UTF8, "application/json");
                var response = await this._httpClient.PutAsync(uri, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                var dsad = ex.Message;
                return false;
            }
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
    }
}
