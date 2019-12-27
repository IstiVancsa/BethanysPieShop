using BethanysPieShop.Pages.Componets;
using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Pages.Users
{
    public class UsersOverviewBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }//this is used so we can call js methods inside our cs files
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

        public async void SayHello(string userName)
        {
            var serializedItem = JsonConvert.SerializeObject(userName);
            await JSRuntime.InvokeVoidAsync("sayHello", serializedItem);
        }
    }
}
