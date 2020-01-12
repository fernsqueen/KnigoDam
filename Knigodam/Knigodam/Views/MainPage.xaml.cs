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

            _viewModel.BookListIsEmpty += BookListIsEmpty;

            _viewModel.BookListIsNotEmpty += BookListIsNotEmpty;

            _viewModel.Autorization();

            this.BindingContext = _viewModel;

        }

        private void BookListIsNotEmpty(object sender, EventArgs e)
        {
            bookList.IsVisible = true;
            EmptyList.IsVisible = false;
        }

        private void BookListIsEmpty(object sender, EventArgs e)
        {
            bookList.IsVisible = false;
            EmptyList.IsVisible = true;
        }

        async private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var bookItem = e.Item as BookItem;
            var book = new Book { Id = bookItem.Id, ImagePath = bookItem.ImagePath,
                                            Title = bookItem.Title};
            BookPage page = new BookPage(book);
            var lv = sender as ListView;
            lv.SelectedItem = null;
            await Navigation.PushAsync(page);
        }

        async private void AddBookButton_Clicked(object sender, EventArgs e)
        {
            AddBookPage page = new AddBookPage(_viewModel.User);
            page.BookListIsUpdated += BookListIsUpdated;
            await Navigation.PushAsync(page);
        }

        async private void DMButton_Clicked(object sender, EventArgs e)
        {
            DMPage page = new DMPage(_viewModel.User);
            await Navigation.PushAsync(page);
        }

        async private void EditButton_Clicked(object sender, EventArgs e)
        {
            UserBooksPage page = new UserBooksPage(_viewModel.User);
            page.BookListIsUpdatedOverall += BookListIsUpdated;
            await Navigation.PushAsync(page);
        }

        private void BookListIsUpdated(object sender, EventArgs e)
        {
            _viewModel.LoadBook();
        }

        async private void advSearch_Clicked(object sender, EventArgs e)
        {
            AdvanceSearchPage page = new AdvanceSearchPage();
            await Navigation.PushAsync(page);
        }

        async private void Authorization(object sender, EventArgs e) 
        {
            var page = new AuthorizationStep1Page();
            await Navigation.PushAsync(page);
        }


        async private void searchBook_SearchButtonPressed(object sender, EventArgs e)
        {
            await _viewModel.Search(searchBook.Text);

            this.BindingContext = _viewModel;
        }

        async private void searchBook_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchBook.Text == "") _viewModel.LoadBook();
            else await _viewModel.Search(searchBook.Text);
        }
    }
}
