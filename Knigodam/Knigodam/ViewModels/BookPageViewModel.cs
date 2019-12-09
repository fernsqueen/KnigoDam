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
    class BookPageViewModel : BaseViewModel
    {
        static void RegisterMyService()
        {
            //Service<IBookService>.RegisterService(new FakeBookService());
            Service<IBookService>.RegisterService(new BookService());
            //Service<IBooksItemService>.RegisterService(new BookItemService());
            //Service<IBooksItemService>.RegisterService(new FakeBookItemService());
        }

        Book _book;

        public string imageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set { SetProperty(ref imageSource, value); }
        }

        public string bookTitle;

        public string BookTitle
        {
            get { return bookTitle; }
            set { SetProperty(ref bookTitle, value); }
        }

        public string description;

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public BookPageViewModel(Book book)
        {
            _book = new Book { Id = book.Id, ImagePath = book.ImagePath, Title = book.Title };
            ImageSource = book.ImagePath;
            BookTitle = book.Title;
            RegisterMyService();
            LoadBook();
        }

        async void LoadBook()
        {
            var result = await GetBook();
            var book = result as Book;
            Description = book.Description;
            _book.Description = book.Description;
            _book.UserId = book.UserId;
        }

        async Task<Book> GetBook()
        {
            var books = await Service<IBookService>.GetInstance().GetBook(_book.Id);
            return books;
        }
    }
}
