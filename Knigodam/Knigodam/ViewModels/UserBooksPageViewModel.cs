using Knigodam.Models;
using Knigodam.Services;
using Knigodam.Services.Fakes;
using Knigodam.Services.Implementation;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.ViewModels
{
    public class UserBooksPageViewModel : BaseViewModel
    {
        static void RegisterMyService()
        {
            //Service<IUserBooksService>.RegisterService(new FakeUserBooksService());
            Service<IUserBooksService>.RegisterService(new UserBooksService());
        }

        public int id;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public List<Book> books;

        public List<Book> Books
        {
            get { return books; }
            set { SetProperty(ref books, value); }
        }

        public UserBooksPageViewModel(User user)
        {
            Id = user.Id;
            Books = new List<Book>();
            //SessionId = sessionId;
            RegisterMyService();
            LoadBook();
        }
        async void LoadBook()
        {
            var result = await GetBooks();
            Books = result;
        }

        async Task<List<Book>> GetBooks()
        {
            var books = await Service<IUserBooksService>.GetInstance().GetUserBooks(Id);
            return books;
        }


    }
}
