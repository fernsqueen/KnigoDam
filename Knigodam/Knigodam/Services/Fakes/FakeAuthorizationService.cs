using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services.Fakes
{
    class FakeAuthorizationService : IAuthorizationService
    {
        public Task<string> Authorization(int smsCode)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetSms(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
