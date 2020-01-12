using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Knigodam.Models;

namespace Knigodam.Services.Fakes
{
    class FakeMessagesService : IMessagesService
    {
        public async Task<List<Message>> GetMessages(int userId)
        {
            return new List<Message>()
            {
                new Message { Title = "Ансамбль звёзд!", ImagePath = "python.jpg", MessageText = "Умоляю отдайте мне эту книгу ну пожалуйста" },
                new Message { Title = "Python", ImagePath = "python.jpg", MessageText = "Здравствуйте! Мой номер 88005553535" }
            };
        }

        public Task<bool> SendMessage(Book book, string message)
        {
            throw new NotImplementedException();
        }
    }
}
