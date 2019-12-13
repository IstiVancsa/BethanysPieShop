using BethanysPieShopHRM.Shared.IServices;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared.DTOs;

namespace BethanysPieShop.Pages.ReviewDetail
{
    public class ReviewDetailBase : ComponentBase
    {
        [Parameter]
        public string ReviewId { get; set; }
        [Inject]
        private IReviewDataService _reviewDataService { get; set; }
        public Review Review { get; set; } = new Review();
        protected override async Task OnInitializedAsync()
        {
            Review = await _reviewDataService.GetReviewAsync(new Guid(ReviewId));
        }
    }
}
