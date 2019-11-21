using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knigodam.ViewModels
{
    class AuthorizationStep1PageViewModel : BaseViewModel
    {
        public string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { SetProperty(ref phoneNumber, value); }
        }
    }
}
