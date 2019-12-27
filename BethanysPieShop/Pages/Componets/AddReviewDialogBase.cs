using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using BethanysPieShopHRM.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BethanysPieShop.Pages.Componets
{
    public class AddReviewDialogBase : ComponentBase
    {
        public ReviewModel Review { get; set; } = new ReviewModel
        {
            Id = new Guid(),
            ReviewComment = "It was great",
            Stars = 5,
            UserId = new Guid()
        };
        [Parameter]//now we can cann it as parameter in razor file
        public EventCallback<bool> CloseEventCallBack { get; set; }//we are sending a message from adduserdialog to users overview

        [Inject]
        public IReviewDataService ReviewDataService { get; set; }
        public bool ShowDialog { get; set; }
        public void Show()
        {
            ResetDialog();
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
            this.Review = new ReviewModel
            {
                Id = new Guid(),
                ReviewComment = "It was great",
                Stars = 5,
                UserId = new Guid()
            };
        }

        protected async Task HandleValidSubmit()
        {
            await ReviewDataService.AddReviewAsync(Review.CastToDTO());

            await CloseEventCallBack.InvokeAsync(true);//we can send even the save employee here

            ShowDialog = false;

            StateHasChanged();
        }
    }
}
