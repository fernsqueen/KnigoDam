using Knigodam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services.Fakes
{
    class FakeBookService : IBookService
    {
        List<Book> books;
        public async Task<Book> GetBook(int id)
        {
            books = new List<Book>()
            {
            new Book {Id = 1, Title="Тобол. Мало избранных", ImagePath="tobol.jpg", Description="Описание1", UserId = 1 },
            new Book {Id = 2, Title="Python для детей", ImagePath="python.jpg", Description="Описание2", UserId = 1},
            new Book {Id = 3, Title="Тонкое искусство пофигизма", ImagePath="pofigizm.jpg", Description="Описание3", UserId = 2 },
            new Book {Id = 4, Title="Центр тяжести", ImagePath="centre.jpg", Description="Описание4", UserId = 1 },
            new Book {Id = 5, Title="123456", ImagePath="centre.jpg", Description="Описание4", UserId = 2 },
            };

            return books[id-1];
        }
    }
}
