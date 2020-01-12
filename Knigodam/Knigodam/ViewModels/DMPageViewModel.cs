using Knigodam.Models;
using Knigodam.Services;
using Knigodam.Services.Implementation;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.ViewModels
{
    class DMPageViewModel : BaseViewModel
    {

        static void RegisterMyService()
        {
            Service<IMessagesService>.RegisterService(new MessagesService());
            //Service<IMessagesService>.RegisterService(new FakeMessagesService());
        }

        public List<Message> messages;
        public List<Message> Messages
        {
            get { return messages; }
            set { SetProperty(ref messages, value); }
        }

        public int userId;

        public int UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
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

        public string messageText;

        public string MessageText
        {
            get { return messageText; }
            set { SetProperty(ref messageText, value); }
        }

        public string shortMessageText;

        public string ShortMessageText
        {
            get { return shortMessageText; }
            set { SetProperty(ref shortMessageText, value); }
        }


        // С датой как-то иначе
        public string messageDate;

        public string MessageDate
        {
            get { return messageDate; }
            set { SetProperty(ref messageDate, value); }
        }

        public event EventHandler MessagesListIsEmpty;
        public event EventHandler MessagesListIsNotEmpty;

        // Передавать User,  вероятно
        public DMPageViewModel(User user)
        {
            RegisterMyService();
            UserId = user.Id;
            LoadMessage();
        }

        public async void LoadMessage()
        {
            var result = await GetMessages();
            Messages = result;
            if (result.Count == 0) MessagesListIsEmpty?.Invoke(this, null);
            else MessagesListIsNotEmpty?.Invoke(this, null);
        }


        async Task<List<Message>> GetMessages()
        {
            var messages = await Service<IMessagesService>.GetInstance().GetMessages(UserId);
            return messages;
        }
    }
}
