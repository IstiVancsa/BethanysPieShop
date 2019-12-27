using BethanysPieShop.Pages.Componets;
using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Pages.Reviews
{
    public class ReviewOverviewBase : ComponentBase
    {
        [Inject]
        IReviewDataService ReviewDataService { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        protected AddReviewDialog AddReviewDialog { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Reviews = await ReviewDataService.GetReviewsAsync();
        }
        protected void AddReview()
        {
            AddReviewDialog.Show();
        }
        public async Task ReviewsListChanged()
        {
            Reviews = (await ReviewDataService.GetReviewsAsync()).ToList();
            StateHasChanged();
        }

        public async void AddReviewDialog_OnDialogClose()
        {
            Reviews = (await ReviewDataService.GetReviewsAsync()).ToList();
            StateHasChanged();
        }
    }
}
