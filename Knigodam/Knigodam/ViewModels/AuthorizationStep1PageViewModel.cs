using Knigodam.Services;
using Knigodam.Services.Fakes;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.ViewModels
{
    class AuthorizationStep1PageViewModel : BaseViewModel
    {
        static void RegisterMyService()
        {
            Service<IAuthorizationService>.RegisterService(new FakeAuthorizationService());
        }

        public string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { SetProperty(ref phoneNumber, value); }
        }

        public AuthorizationStep1PageViewModel()
        {
            RegisterMyService();
        }

        public event EventHandler AuthorizationStep2Open;

        public void GetCode(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            GetCodeForAuth();
            AuthorizationStep2Open?.Invoke(this, null);
        }

        async void GetCodeForAuth()
        {
            var result = await GetCodeFrom();
            SmsCode = result;
        }

        public int SmsCode { get; set; }

        async Task<int> GetCodeFrom()
        {
            var code = await Service<IAuthorizationService>.GetInstance().GetSms(phoneNumber);
            return code;
        }
    }
}
