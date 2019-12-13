using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BethanysPieShop.Pages.UserDetail
{
    public class UserDetailBase : ComponentBase
    {
        [Inject]
        public IUserDataService UserDataService { get; set; }
        [Parameter]
        public string UserId { get; set; }
        public User User { get; set; } = new User();

        protected override async Task OnInitializedAsync()
        {
            User = await UserDataService.GetUserAsync(new Guid(UserId));
        }
    }
}