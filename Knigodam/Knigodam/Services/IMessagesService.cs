using Knigodam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services
{
    interface IMessagesService
    {
        Task<List<Message>> GetMessages(int userId);
        Task<bool> SendMessage(Book book, string message);
    }
}
