using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private string _role = "Customers";

        public AccountController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //You will be allowed to access these even if you arent authorized
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        //Must use Task<> When using async methods
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                //Async methods must use await when calling it
                AppUser user =
                  await _userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,
                      loginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Home/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(loginModel);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                if (await _roleManager.FindByNameAsync(_role) == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole(_role));
                }
                var user = new AppUser
                {
                    UserName = registerModel.UserName,
                    Email = registerModel.Email
                };

                //Code for avatar image
                if (registerModel.AvatarImage != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await registerModel.AvatarImage.CopyToAsync(memoryStream);
                        user.AvatarImage = memoryStream.ToArray();
                    }
                }
                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, _role);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to register new user");
                }
            }
            return View(registerModel);
        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}