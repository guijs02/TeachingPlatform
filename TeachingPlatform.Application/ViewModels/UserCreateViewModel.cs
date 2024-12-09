﻿using System.ComponentModel.DataAnnotations;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        public ETypeOfUser TypeOfUser { get; set; }
    }
}
