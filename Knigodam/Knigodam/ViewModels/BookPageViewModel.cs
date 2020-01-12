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
            Service<IMessagesService>.RegisterService(new MessagesService());
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

        public string author;

        public string Author
        {
            get { return author; }
            set { SetProperty(ref author, value); }
        }

        public string publisher;

        public string Publisher
        {
            get { return publisher; }
            set { SetProperty(ref publisher, value); }
        }

        public string language;

        public string Language
        {
            get { return language; }
            set { SetProperty(ref language, value); }
        }

        public int year;

        public int Year
        {
            get { return year; }
            set { SetProperty(ref year, value); }
        }

        public BookPageViewModel(Book book)
        {
            _book = new Book { Id = book.Id, ImagePath = book.ImagePath, Title = book.Title};
            ImageSource = book.ImagePath;
            BookTitle = book.Title;
            RegisterMyService();
            LoadBook();
        }

        public event EventHandler OnBookSetted;

        async void LoadBook()
        {
            var result = await GetBook();
            var book = result as Book;
            Description = book.Description;
            Author = book.Author;
            Year = book.Year;
            Publisher = book.PublishingHouse;
            Language = book.Language;
            _book.Description = book.Description;
            _book.UserId = book.UserId;
            _book.Author = book.Author;
            OnBookSetted?.Invoke(this, null);
        }

        async Task<Book> GetBook()
        {
            var books = await Service<IBookService>.GetInstance().GetBook(_book.Id);
            return books;
        }

        public async Task<bool> SendMessage(string _text)
        {
            var mess = await Service<IMessagesService>.GetInstance().SendMessage(_book, _text);
            return mess;
        }
    }
}
