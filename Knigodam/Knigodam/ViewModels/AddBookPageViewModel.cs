using Knigodam.Models;
using Knigodam.Services;
using Knigodam.Services.Implementation;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knigodam.ViewModels
{
    class AddBookPageViewModel : BaseViewModel
    {
        static void RegisterMyService()
        {
            Service<IAddBookService>.RegisterService(new AddBookService());
        }

        public User user;

        public User User_
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        public Book book;

        public Book Book_
        {
            get { return book; }
            set { SetProperty(ref book, value); }
        }

        public AddBookPageViewModel()
        {
            RegisterMyService();
        }

        public async void AddBook()
        {
            await Service<IAddBookService>.GetInstance().AddBook(book);
        }
    }
}
