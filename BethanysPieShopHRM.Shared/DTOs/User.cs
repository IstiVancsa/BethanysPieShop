﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Shared.DTOs
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid Token { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
