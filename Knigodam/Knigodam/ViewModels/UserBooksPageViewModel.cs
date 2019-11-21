using Knigodam.Models;
using Knigodam.Services;
using Knigodam.Services.Fakes;
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
            Service<IUserBooks>.RegisterService(new FakeUserBooksService());
        }
        public List<Book> Books { get; set; }

        public string sessionId;
        public string SessionId
        {
            get { return sessionId; }
            set { SetProperty(ref sessionId, value); }
        }
        public UserBooksPageViewModel()
        {
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
            var books = await Service<IUserBooks>.GetInstance().GetUserBooks();
            return books;
        }


    }
}
