using BethanysPieShop.Pages.Users;
using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Components.EditUser
{
    public class EditUserDialogBase : ComponentBase
    {
        [Inject]
        public IUserDataService UserDataService { get; set; }
        public User User { get; set; }
        [Parameter]
        public EventCallback<bool> EditEventCallBack { get; set; }
        protected UsersOverview UsersOverview { get; set; }
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

        protected async Task HandleValidSubmit()
        {
            await UserDataService.UpdateUserAsync(User);
            await EditEventCallBack.InvokeAsync(true);
            ShowDialog = false;

            StateHasChanged();
        }
        public async void PopulateTextBoxes(Guid userId)
        {
            User = await UserDataService.GetUserAsync(userId);
        }
    }
}
