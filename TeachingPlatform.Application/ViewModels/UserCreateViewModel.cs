using System.ComponentModel.DataAnnotations;

namespace TeachingPlatform.Application.ViewModels
{
    public class UserCreateViewModel
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
