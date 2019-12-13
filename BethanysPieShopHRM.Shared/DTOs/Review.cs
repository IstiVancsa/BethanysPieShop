using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared.DTOs
{
    public class Review
    {
        public Guid Id { get; set; }
        public string ReviewComment { get; set; }
        public int Stars { get; set; }
        public Guid UserId { get; set; }
    }
}
