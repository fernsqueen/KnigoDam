using Knigodam.Models;
using Knigodam.Services;
using Knigodam.Services.Fakes;
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
    public partial class AuthorizationStep1Page : ContentPage
    {
        AuthorizationStep1PageViewModel _viewModel;
        public AuthorizationStep1Page()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            _viewModel = new AuthorizationStep1PageViewModel();
            _viewModel.AuthorizationStep2Open += AuthorizationStep2Open;
            _viewModel.PhoneCheckError += PhoneCheckError;
        }

        private void PhoneCheckError(object sender, EventArgs e)
        {
            CodeError.Text = "Неверный формат номера";
        }

        async private void AuthorizationStep2Open(object sender, EventArgs e)
        {
            var page = new AuthorizationStep2Page();
            await Navigation.PushAsync(page);
        }

        async private void SubmitNumber_Clicked(object sender, EventArgs e)
        {
            if (PhoneNumber.Text != null) _viewModel.GetCode(PhoneNumber.Text);
            else CodeError.Text = "Пожалуйста, введите номер";

        }



    }
}