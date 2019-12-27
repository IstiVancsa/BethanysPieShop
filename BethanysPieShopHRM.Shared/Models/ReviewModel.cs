using BethanysPieShopHRM.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared.Models
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public string IdDisplayed
        {
            get => this.UserId.ToString();
            set => this.UserId = new Guid(value);
        }
        public string ReviewComment { get; set; }
        public int Stars { get; set; }
        public Guid UserId { get; set; }
        public Review CastToDTO() 
        {
            return new Review
            {
                Id = this.Id,
                ReviewComment = this.ReviewComment,
                Stars = this.Stars,
                UserId = this.UserId
            };
        } 
    }
}
