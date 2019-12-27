using BethanysPieShop.Pages.Componets;
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
        protected override async Task OnInitializedAsync()
        {
            Users = await UserDataService.GetUsersAsync();
        }
        protected void AddUser()
        {
            AddUserDialog.Show();
        }
        protected void EditUser(User user)
        {
            EditUserDialog.User.Age = user.Age;
            EditUserDialog.User.Username = user.Username;
            EditUserDialog.User.Password = user.Password;
            EditUserDialog.User.Id = user.Id;
            EditUserDialog.User.Token = user.Token;
            EditUserDialog.Show();
        }

        public async Task UsersListChanged()
        {
            Users = (await UserDataService.GetUsersAsync()).ToList();
            StateHasChanged();
        }

        public async void AddUserDialog_OnDialogClose()
        {
            Users = (await UserDataService.GetUsersAsync()).ToList();
            StateHasChanged();
        }
        public async void EditUserDialog_OnDialogClose()
        {
            Users = (await UserDataService.GetUsersAsync()).ToList();
            StateHasChanged();
        }
    }
}
