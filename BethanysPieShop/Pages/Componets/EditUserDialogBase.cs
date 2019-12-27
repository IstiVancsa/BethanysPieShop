using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BethanysPieShop.Pages.Componets
{
    public class EditUserDialogBase : ComponentBase
    {
        public User User { get; set; } = new User();
        [Parameter]//now we can cann it as parameter in razor file
        public EventCallback<bool> CloseEventCallBack { get; set; }//we are sending a message from edituserdialog to users overview
        [Inject]
        public IUserDataService UserDataService { get; set; }
        
        public bool ShowDialog { get; set; }
        public void Show()
        {
            //ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            this.User = new User
            {
                Id = new Guid(),
                Age = 69,
                Password = "1234",
                Username = "Gigel"
            };
        }
        protected async Task HandleValidSubmit()
        {
            await UserDataService.UpdateUserAsync(User);

            await CloseEventCallBack.InvokeAsync(true);//we can send even the saved user here

            ShowDialog = false;

            StateHasChanged();
        }
    }
}
