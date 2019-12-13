using BethanysPieShopHRM.Shared.DTOs;
using BethanysPieShopHRM.Shared.IServices;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BethanysPieShop.Pages.Reviews
{
    public class ReviewOverviewBase : ComponentBase
    {
        [Inject]
        IReviewDataService ReviewDataService { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Reviews = await ReviewDataService.GetReviewsAsync();
        }
    }
}
