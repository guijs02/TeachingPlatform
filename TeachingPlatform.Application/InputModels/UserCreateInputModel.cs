using System.ComponentModel.DataAnnotations;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Application.InputModels
{
    public class UserCreateInputModel
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
        public EUserRole TypeOfUser { get; set; }
    }
}
