using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
//Classes that will be used by the user
namespace SportsStore.Models.ViewModels
{  
    public class LoginModel
    {
        [Required]
        //UIHint gives hint to user that its an email
        [UIHint("email")]
        public string Email { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must match")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public IFormFile  AvatarImage { get; set; }
    }
}