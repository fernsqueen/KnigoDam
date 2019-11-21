using Knigodam.Services;
using Knigodam.Services.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Knigodam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationStep1Page : ContentPage
    {
        static void RegisterMyService()
        {
            Service<IAuthorizationService>.RegisterService(new FakeAuthorizationService());
        }
        string sessionId { get; set; }
        public AuthorizationStep1Page()
        {
            InitializeComponent();
        }

        private void SubmitNumber_Clicked(object sender, EventArgs e)
        {

        }
    }
}