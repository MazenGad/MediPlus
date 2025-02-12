using MediPlus.Data.Users;
using MediPlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MediPlus.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SaveRegister(RegisterUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var appUser = new ApplicationUser();
                appUser.Email = userViewModel.Email;
                appUser.UserName = userViewModel.UserName;
                appUser.PasswordHash = userViewModel.Password;

                var result = await _userManager.CreateAsync(appUser, userViewModel.Password);

                if (result.Succeeded)
                {
                    var additionalClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.StreetAddress, appUser.Address = appUser.Address ?? "Not Provided" ),
                    };

                    await _signInManager.SignInWithClaimsAsync(appUser, false, additionalClaims);
                    return RedirectToAction("Create", "Doctor");
                }
                foreach (var r in result.Errors)
                {
                    ModelState.AddModelError("", r.Description);
                }
            }

            return View("Register", userViewModel);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SaveLogin(SignInUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByNameAsync(userViewModel.UserName);
                if(appUser != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(appUser, userViewModel.Password);
                    if (found)
                    {
                        await _signInManager.SignInAsync(appUser, userViewModel.RememberMe);
                        return RedirectToAction("Create", "Doctor");
                    }
                }
                ModelState.AddModelError("", "UserName Or Password Wrong");
            }
            return View("SignIn", userViewModel);
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");

        }
    }
}
