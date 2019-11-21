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
    public class MainPageViewModel : BaseViewModel
    {
        static void RegisterMyService()
        {
            Service<IBooksService>.RegisterService(new FakeBooksService());
        }

        public List<Book> Books { get; set; }

        public string SessionId { get; set; }

        public MainPageViewModel()
        {
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
            var books = await Service<IBooksService>.GetInstance().GetBooks();
            return books;
        }

        async Task<string> GetSessionId()
        {
            var sessionId = await GetSessionId();
            return sessionId;
        }
    }
}
