using Login.Models;
using Login.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Services.AccountServices
{
    public interface ILoginService
    {
        Task<LoginResult> Login(LoginUser LoginUser);
        void Signout();
        Task<List<User>> GetUsers();
    }
}
