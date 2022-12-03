using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Pages.Roles
{
    public class ListModel : AdminPageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ListModel(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IEnumerable<IdentityRole> Roles { get; set; }

        public void OnGet()
        {
            Roles = _roleManager.Roles;
        }

        public async Task<string> GetMembersString(string role)
        {
            IEnumerable<AppUser> users
                = (await _userManager.GetUsersInRoleAsync(role));

            string result = users.Count() == 0
                ? "No members"
                : string.Join(", ", users.Take(3).Select(u => u.UserName).ToArray());

            return users.Count() > 3 ? $"{result}, (plus others)" : result;
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToPage();
        }
    }
}
