using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Components.AddUser
{
    //The components are parts of pages so for the simple way that we want to use the across all the projects we will create another class library for them

    public class AddUserDialogBase : ComponentBase
    {
        [Inject]
        public IUserDataService UserDataService { get; set; }
        [Parameter]
        public EventCallback<bool> AddEventCallBack { get; set; }
        public User User { get; set; } = new User { Id = new Guid(), Age = 0, Password = "1234", Reviews = new List<Review>(), Token = new Guid(), Username = "Gigel" };
        public bool ShowDialog { get; set; }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }
        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }
        public void ResetDialog()
        {
            User = new User { Id = new Guid(), Age = 0, Password = "1234", Reviews = new List<Review>(), Token = new Guid(), Username = "Gigel" };
        }

        protected async Task HandleValidSubmit()
        {
            await UserDataService.AddUserAsync(User);
            await AddEventCallBack.InvokeAsync(true);
            ShowDialog = false;

            StateHasChanged();
        }

    }
}
