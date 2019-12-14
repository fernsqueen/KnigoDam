using Knigodam.Models;
using Knigodam.Services;
using Knigodam.Services.Implementation;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knigodam.ViewModels
{
    class EditBookViewModel : BaseViewModel
    {
        static void RegisterMyService()
        {
            Service<IEditBookService>.RegisterService(new EditBookService());
        }

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

        public int id;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public string status;

        public string Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

        public EditBookViewModel(Book book)
        {
            ImageSource = book.ImagePath;
            BookTitle = book.Title;
            Id = book.Id;
            RegisterMyService();
        }

        async public void Delete()
        {
            await Service<IEditBookService>.GetInstance().DeleteBook(Id);
        }

        async public void Edit(string status)
        {
            await Service<IEditBookService>.GetInstance().EditBookStatus(Id, status);
        }
    }
}
