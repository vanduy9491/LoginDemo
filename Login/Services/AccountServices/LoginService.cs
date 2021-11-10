using Login.Models;
using Login.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Services.AccountServices
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly BasicSkillsContext context;

        public LoginService(UserManager<User> userManager,
                            SignInManager<User> signInManager,
                            RoleManager<IdentityRole> roleManager,
                            BasicSkillsContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.context = context;
        }
        [HttpGet]
        public Task<List<User>> GetUsers()
        {
            var users = context.Users.ToListAsync();
            return users;
        }

        public async Task<LoginResult> Login(LoginUser LoginUser)
        {
            var user = await userManager.FindByNameAsync(LoginUser.Username);
            if (user == null)
            {
                return new LoginResult()
                {
                    UserId = string.Empty,
                    Username = string.Empty,
                    Message = "User is not existing."
                };
            }
            var signInResult = await signInManager.PasswordSignInAsync(user, LoginUser.Password, LoginUser.Remember, false);
            if (signInResult.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(user);
                return new LoginResult()
                {
                    UserId = user.Id,
                    Username = user.Email,
                    Message = "Login successed",
                    Roles = roles.ToArray()
                };
            }
            return new LoginResult()
            {
                UserId = string.Empty,
                Username = string.Empty,
                Message = "Password went wrong, please try again"
            };
        }
        public void Signout()
        {
            signInManager.SignOutAsync().Wait();
        }
    }
}
