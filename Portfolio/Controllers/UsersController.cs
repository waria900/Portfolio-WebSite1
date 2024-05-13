using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Bl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

namespace Portfolio.Controllers
{

    public class UsersController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Login(string ReturnUrl)
        {
            UserModel model = new UserModel()
            {
                ReturnUrl = ReturnUrl
            };

            return View(model);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserModel model)
        {
            if (!ModelState.IsValid)
                return View("Login", model);

            ApplicationUser user = new ApplicationUser()
            {

                Email = model.Email,
                UserName = model.Email
            };

            try
            {
                var myEmail = await _userManager.FindByEmailAsync(user.Email);

               
                var loginResult = await _signInManager.PasswordSignInAsync(myEmail, model.Password, true, true);
                
               
                     

                if (loginResult.Succeeded)
                {

                    var myAdmins = await _userManager.FindByEmailAsync(user.Email);
                    if (myAdmins != null && (await _userManager.IsInRoleAsync(myAdmins, "Admin")))
                        return Redirect("~/Admin");
                    
                       


                    if (string.IsNullOrEmpty(model.ReturnUrl))

                        return Redirect("~/");
                    else
                        return Redirect(model.ReturnUrl);

                }


            }
            catch(Exception ex)
            {
                TempData["error"] = "please enter a valid credintals";
            }


            TempData["error"] = "please enter a valid credintals";

            return View(new UserModel());
        }


    


        public async Task<IActionResult> LoginOut()
        {
            await _signInManager.SignOutAsync();
            // This means the root page for example:   return Redirect("~Home/index");
            return Redirect("~/");
        }



        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
