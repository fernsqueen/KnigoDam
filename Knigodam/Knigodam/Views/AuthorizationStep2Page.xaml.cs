using Knigodam.Models;
using Knigodam.ViewModels;
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
    public partial class AuthorizationStep2Page : ContentPage
    {
        AuthorizationStep2PageViewModel _viewModel;
        public AuthorizationStep2Page()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            _viewModel = new AuthorizationStep2PageViewModel();
            _viewModel.AuthorizatedMainPageOpen += AuthorizatedMainPage;
        }

        async private void AuthorizatedMainPage(object sender, EventArgs e)
        {
            var page = new MainPage(_viewModel.SessionId);
            await Navigation.PushAsync(page);
        }

        async private void SubmitCode_Clicked(object sender, EventArgs e)
        {
            if (Code.Text != null) _viewModel.Authorizate(int.Parse(Code.Text));
            else CodeError.Text = "Пожалуйста, введите код";
        }
    }
}