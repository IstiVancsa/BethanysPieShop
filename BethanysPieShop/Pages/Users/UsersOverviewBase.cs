using BethanysPieShop.Pages.Componets.AddUser;
using BethanysPieShop.Pages.EditUserComponent;
using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Pages.Users
{
    public class UsersOverviewBase : ComponentBase
    {
        [Inject]
        public IUserDataService UserDataService { get; set; }
        public IEnumerable<User> Users { get; set; }
        protected AddUserDialog AddUserDialog { get; set; }
        protected EditUserDialog EditUserDialog { get; set; }
        [Parameter]
        public EventCallback<User> OpenEditPopUp { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Users = await UserDataService.GetUsersAsync();
        }
        protected void AddUser()
        {
            AddUserDialog.Show();
        }
        protected async void EditUser(User user)
        {
            await OpenEditPopUp.InvokeAsync(user);
            EditUserDialog.Show();
        }

        public async void UsersListChanged()
        {
            Users = (await UserDataService.GetUsersAsync()).ToList();
            StateHasChanged();
        }
    }
}
