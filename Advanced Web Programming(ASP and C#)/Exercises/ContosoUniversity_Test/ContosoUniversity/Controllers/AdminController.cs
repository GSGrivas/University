using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Models.ViewModels;
using System.Threading.Tasks;

namespace ContosoUniversity.Controllers
{
    public class AdminController : Controller
    {
        
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

   
        public ViewResult Index()
        {
            //Provides a list of all the users
            return View(_userManager.Users);
        }

        public ViewResult Create()
        {
            return View();
        }

        //Creates a user
        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result
                    = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
