using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BethanysPieShop.Pages.Users
{
    public class UsersOverviewBase : ComponentBase
    {
        [Inject]
        public IUserDataService UserDataService { get; set; }
        public IEnumerable<User> Users { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Users = await UserDataService.GetUsersAsync();
        }
    }
}
