using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Pages.Users
{
    public class ListModel : AdminPageModel
    {
        private readonly UserManager<AppUser> _userManager;
        public ListModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IEnumerable<AppUser> Users { get; set; }

        public void OnGet()
        {
            Users = _userManager.Users;
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToPage();
        }
    }
}
