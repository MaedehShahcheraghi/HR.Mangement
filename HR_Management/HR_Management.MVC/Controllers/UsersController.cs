using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public UsersController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        #region Login
        public async Task<IActionResult> Login(string ReturnUrl = null)
        {
           ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {

            login.ReturnUrl ??= Url.Content("/");
            var result = await authenticationService.Authenticate(login.Email, login.Password);
            if (result)
            {
                return LocalRedirect(login.ReturnUrl);
            }
            ModelState.AddModelError("", "login faild ... try again later");
            return View(login);
        }

        #endregion

        #region Register
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            var result = await authenticationService.Register(registerVM);
            if (result) {
                return LocalRedirect("/");
            }
            ModelState.AddModelError("", "Creation faild ... try again later");
            return View(registerVM);
        }
        #endregion

        #region LogOut
        [HttpPost]
        public async Task<IActionResult> LogOut()
        { 
           await authenticationService.LogOut(); 
            return LocalRedirect("/Users/Login");
        }
        #endregion

        }
}
