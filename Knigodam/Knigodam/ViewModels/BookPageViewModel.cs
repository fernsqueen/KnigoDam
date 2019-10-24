using Knigodam.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knigodam.ViewModels
{
    class BookPageViewModel : BaseViewModel
    {
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
            ImageSource = book.ImagePath;
            BookTitle = book.Title;
            Description = book.Description;
        }
    }
}
