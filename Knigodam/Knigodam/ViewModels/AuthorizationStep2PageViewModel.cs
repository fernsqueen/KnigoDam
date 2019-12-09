using Knigodam.Services;
using Knigodam.Services.Fakes;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.ViewModels
{
    class AuthorizationStep2PageViewModel : BaseViewModel
    {
        static void RegisterMyService()
        {
            Service<IAuthorizationService>.RegisterService(new FakeAuthorizationService());
        }

        public int code;

        public int Code
        {
            get { return code; }
            set { SetProperty(ref code, value); }
        }

        public AuthorizationStep2PageViewModel()
        {
            RegisterMyService();
        }

        public event EventHandler AuthorizatedMainPageOpen;

        public void Authorizate(int smsCode)
        {
            Code = smsCode;
            GetSessionId();
            AuthorizatedMainPageOpen?.Invoke(this, null);
        }

        async void GetSessionId()
        {
            var result = await GetSessionIdFrom();
            SessionId = result;
        }

        public string SessionId { get; set; }

        async Task<string> GetSessionIdFrom()
        {
            var sessionId = await Service<IAuthorizationService>.GetInstance().Authorization(Code);
            return sessionId;
        }
    }
}