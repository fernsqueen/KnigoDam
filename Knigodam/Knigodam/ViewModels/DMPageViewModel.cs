using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knigodam.ViewModels
{
    class DMPageViewModel : BaseViewModel
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

        public string messageText;

        public string MessageText
        {
            get { return messageText; }
            set { SetProperty(ref messageText, value); }
        }


        // С датой как-то иначе
        public string messageDate;

        public string MessageDate
        {
            get { return messageDate; }
            set { SetProperty(ref messageDate, value); }
        }

        // Передавать User,  вероятно
        public DMPageViewModel()
        {
        }
    }
}
