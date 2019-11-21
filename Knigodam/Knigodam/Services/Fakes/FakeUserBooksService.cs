using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Knigodam.Models;

namespace Knigodam.Services.Fakes
{
    public class FakeUserBooksService : IUserBooks
    {
        public async Task<List<Book>> GetUserBooks()
        {
            return new List<Book>()
            {
            new Book {Title="Тобол. Мало избранных", ImagePath="tobol.jpg", Description="Описание1" },
            new Book {Title="Python для детей", ImagePath="python.jpg", Description="Описание2" },
            };
        }
    }
}
