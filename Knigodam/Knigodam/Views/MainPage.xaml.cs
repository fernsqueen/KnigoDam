using DocumentFormat.OpenXml.Drawing;
using Knigodam.Models;
using Knigodam.Services;
using Knigodam.Services.Fakes;
using Knigodam.ViewModels;
using Knigodam.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Knigodam
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            _viewModel = new MainPageViewModel();

            this.BindingContext = _viewModel;
         
        }

        async private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var book = e.Item as Book;
            BookPage page = new BookPage(book);
            var lv = sender as ListView;
            //lv.IsEnabled = false;
            lv.SelectedItem = null;
            await Navigation.PushAsync(page);
        }

        async private void AddBookButton_Clicked(object sender, EventArgs e)
        {
            AddBookPage page = new AddBookPage();
            await Navigation.PushAsync(page);
        }

        async private void DMButton_Clicked(object sender, EventArgs e)
        {
            if (_viewModel.SessionId == null) Authorization();
            DMPage page = new DMPage();
            await Navigation.PushAsync(page);
        }

        async private void EditButton_Clicked(object sender, EventArgs e)
        {
            if (_viewModel.SessionId == null) Authorization();
            UserBooksPage page = new UserBooksPage();
            await Navigation.PushAsync(page);
        }

        async private void advSearch_Clicked(object sender, EventArgs e)
        {
            if (_viewModel.SessionId == null) Authorization();
            AdvanceSearchPage page = new AdvanceSearchPage();
            await Navigation.PushAsync(page);
        }

        async private void Authorization()
        {
            // regist
            // vm id = flgkglgfk
        }
    }
}
