using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Knigodam.Models;

namespace Knigodam.Services.Fakes
{
    class FakeAuthorizationService : IAuthorizationService
    {
        public async Task<string> Authorization(int smsCode)
        {
            string sessionId = "ThisIsUserWithID=" + smsCode.ToString();
            return sessionId;
        }

        public async Task<int> GetSms(string phoneNumber)
        {
            return int.Parse(phoneNumber);
        }

        public async Task<bool> IsAuthorizate(string phoneNumber)
        {
            if (phoneNumber == "UserIsAuthorizated") return true;
            else return false;
        }

        public async Task<User> GetUser(string sessionCode)
        {
            var userId = int.Parse(sessionCode.Split("=")[1]);
            return new User
            {
                Number = "UserIsAuthorizated",
                Id = userId
            };
        }

    }
}
