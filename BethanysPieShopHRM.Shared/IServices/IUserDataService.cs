using BethanysPieShopHRM.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Shared.IServices
{
    public interface IUserDataService
    {
        Task<bool> AddUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid id);
        Task<User> GetUserAsync(Guid id);
        Task<IList<User>> GetUsersAsync();
        Task<IList<User>> GetUsersAsync(string filters);
        Task<bool> UpdateUserAsync(User user);
        Task<TResult> ReturnGetHttp<TResult>(string url);
    }
}
