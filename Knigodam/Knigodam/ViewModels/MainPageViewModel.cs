using Knigodam.Models;
using Knigodam.Services;
using Knigodam.Services.Fakes;
using Knigodam.Services.Implementation;
using Knigodam.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Knigodam.ViewModels
{

    public class MainPageViewModel : BaseViewModel
    {
        static void RegisterMyService()
        {
            Service<IBooksItemService>.RegisterService(new BookItemService());
            // FakeAuthorizationService
            //Service<IBooksItemService>.RegisterService(new FakeBookItemService());

            Service<IAuthorizationService>.RegisterService(new FakeAuthorizationService());

            Service<ISearchService>.RegisterService(new SearchService());
        }

        public event EventHandler AuthorizationOpen;

        public List<BookItem> books;

        public List<BookItem> Books
        {
            get { return books; }
            set { SetProperty(ref books, value); }
        }


        public User User { get; set; }

        public string SessionCode { get; set; }

        public MainPageViewModel(string sessionCode)
        {
            RegisterMyService();
            SessionCode = sessionCode;
            Autorization();
            LoadBook();
        }

        public async void Autorization()
        {
            
            if (SessionCode == "")
            {
                AuthorizationOpen?.Invoke(this, null);
            }            
            else 
            {
                GetUser();
                AuthorizationCheck();
                if (!AuthorizationStatus)
                    AuthorizationOpen?.Invoke(this, null);
            }
        }

        public event EventHandler BookListIsEmpty;
        public event EventHandler BookListIsNotEmpty;

        public async void LoadBook()
        {
            var result = await GetBooks();
            Books = result;
            if (result.Count == 0) BookListIsEmpty?.Invoke(this, null);
            else BookListIsNotEmpty?.Invoke(this, null);
        }


        async Task<List<BookItem>> GetBooks()
        {
            var books = await Service<IBooksItemService>.GetInstance().GetBooks();
            return books;
        }

        async void AuthorizationCheck()
        {
            var result = await IsAuthorizated();
            AuthorizationStatus = result;
        }

        bool AuthorizationStatus { get; set; }

        async Task<bool> IsAuthorizated()
        {
            var isAuth = await Service<IAuthorizationService>.GetInstance().IsAuthorizate(User.Number);
            return isAuth;
        }

        async void GetUser()
        {
            var result = await GetUserFrom();
            User = result;
        }

        async Task<User> GetUserFrom()
        {
            var user = await Service<IAuthorizationService>.GetInstance().GetUser(SessionCode);
            return user;
        }

        public async Task<bool> Search(string entry)
        {
            var result = await GetSearchedBooks(entry);
            Books = result;
            if (result.Count == 0) BookListIsEmpty?.Invoke(this, null);
            else BookListIsNotEmpty?.Invoke(this, null);
            return true;
        }


        async Task<List<BookItem>> GetSearchedBooks(string entry)
        {
            var books = await Service<ISearchService>.GetInstance().GetSimpleSearchedBooks(entry);
            return books;
        }
    }
}
