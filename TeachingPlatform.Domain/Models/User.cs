﻿using Microsoft.AspNetCore.Identity;

namespace TeachingPlatform.Domain.Models
{
    public class User : IdentityUser
    {
        public string Password { get; set; } = null!;
    }
}
