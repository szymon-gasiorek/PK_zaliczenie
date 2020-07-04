using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PK_zaliczenie_web_1.Models;
using PK_zaliczenie_web_1.ViewModels;

namespace PK_zaliczenie_web_1.Constollers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

       

        public AccountController(UserManager<IdentityUser> userManager 
            ,SignInManager<IdentityUser> signInManager )
        {
            this.signInManager = signInManager;
          
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModelcs model)
        {
            if (ModelState.IsValid)
            {
                RegisterViewModelcs m = new RegisterViewModelcs
                {
                    Role = model.Role
                };




                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                // nie dziala jak powinno
                IdentityResult role = await userManager.AddToRoleAsync(user,m.Role.ToString());
                if (result.Succeeded && role.Succeeded)
                {
                   await signInManager.SignInAsync(user, false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, 
                    model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                   
                }

                ModelState.AddModelError(string.Empty, "Invalid log in data");

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpPost][HttpGet]
        public async Task<IActionResult> IsEmailUsed(string email)
        {
           var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already taken");
            }
        }


    }
}
