using Knigodam.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knigodam.ViewModels
{
    class EditBookViewModel : BaseViewModel
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

        public EditBookViewModel(Book book)
        {
            ImageSource = book.ImagePath;
            BookTitle = book.Title;
        }
    }
}
