using Login.Models.Accounts;
using Login.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService loginService;

        public AccountController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser login)
        {
            if (ModelState.IsValid)
            {
                var result = await loginService.Login(login);
                if (result.Success && result.Roles.Length > 0)
                {
                    if (result.Roles.Contains("sensei"))
                    {
                       TempData["userRole"] = result.Roles;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Privacy", "Home");
                    }
                }
                ViewBag.Error = result.Message;
                return View();
            }
            return View();
        }
    }
}
