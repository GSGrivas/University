using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Pages.Roles
{
    public class EditorModel : AdminPageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EditorModel(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IdentityRole Role { get; set; }

        public async Task<IList<AppUser>> Members()
        {
            return await _userManager.GetUsersInRoleAsync(Role.Name);
        }


        public async Task<IEnumerable<AppUser>> NonMembers()
        {
            return _userManager.Users.ToList().Except(await Members());
        }

        public async Task OnGetAsync(string id)
        {
            Role = await _roleManager.FindByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(string userid, string rolename)
        {
            Role = await _roleManager.FindByNameAsync(rolename);
            AppUser user = await _userManager.FindByIdAsync(userid);
            IdentityResult result;

            if (await _userManager.IsInRoleAsync(user, rolename))
            {
                result = await _userManager.RemoveFromRoleAsync(user, rolename);
            }
            else
            {
                result = await _userManager.AddToRoleAsync(user, rolename);
            }

            if (result.Succeeded)
            {
                return RedirectToPage();
            }
            else
            {
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
                return Page();
            }
        }
    }
}
