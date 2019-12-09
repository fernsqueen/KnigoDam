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
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Knigodam
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;

        public MainPage(string sessionCode)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            _viewModel = new MainPageViewModel(sessionCode);

            _viewModel.AuthorizationOpen += Authorization;

            _viewModel.Autorization();

            //_viewModel.User = new User { Id = 1, Number = "1234" };

            this.BindingContext = _viewModel;

        }

        async private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var bookItem = e.Item as BookItem;
            var book = new Book { Id = bookItem.Id, ImagePath = bookItem.ImagePath,
                                            Title = bookItem.Title};
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
            if (_viewModel.User == null)
            {
                //var _page = new AuthorizationStep1Page();
                //page.GetUser += OnUserAuthorizated;
                //await Navigation.PushAsync(_page);
            }

            _viewModel.User = new User { Id = 1, Number = "1234" };
            DMPage page = new DMPage();
            await Navigation.PushAsync(page);
        }

        async private void EditButton_Clicked(object sender, EventArgs e)
        {
            if (_viewModel.User == null) Authorization(sender, e);
            UserBooksPage page = new UserBooksPage(_viewModel.User);
            await Navigation.PushAsync(page);
        }

        async private void advSearch_Clicked(object sender, EventArgs e)
        {
            if (_viewModel.User == null) Authorization(sender, e);
            AdvanceSearchPage page = new AdvanceSearchPage();
            await Navigation.PushAsync(page);
        }

        async private void Authorization(object sender, EventArgs e) 
        {
            var page = new AuthorizationStep1Page();
            await Navigation.PushAsync(page);
        }

        private void OnUserAuthorizated(object sender, User user)
        {
            _viewModel.User = user;
        }

        async private void searchBook_SearchButtonPressed(object sender, EventArgs e)
        {
            await _viewModel.Search(searchBook.Text);

            this.BindingContext = _viewModel;
        }
    }
}
