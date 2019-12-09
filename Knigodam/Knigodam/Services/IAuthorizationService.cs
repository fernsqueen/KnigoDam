using Knigodam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services
{
    interface IAuthorizationService
    {
        Task<int> GetSms(string phoneNumber);
        Task<string> Authorization(int smsCode);

        Task<bool> IsAuthorizate(string phoneNumber);

        Task<User> GetUser(string sessionCode);
    }
}
