using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Pages.Users
{
    public class CreateModel : AdminPageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
               
        [BindProperty]
        [Required]
        public string UserName { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = UserName,
                    Email = Email
                };

                IdentityResult result =
                    await _userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    return RedirectToPage("List");
                }

                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return Page();
        }
    }
}