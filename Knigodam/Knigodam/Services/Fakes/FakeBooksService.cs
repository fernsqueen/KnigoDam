using Knigodam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services.Fakes
{
    class FakeBooksService : IBooksService
    {
        public async Task<List<Book>> GetBooks()
        {
            return new List<Book>()
            {
            new Book {Title="Тобол. Мало избранных", ImagePath="tobol.jpg", Description="Описание1" },
            new Book {Title="Python для детей", ImagePath="python.jpg", Description="Описание2" },
            new Book {Title="Тонкое искусство пофигизма", ImagePath="pofigizm.jpg", Description="Описание3" },
            new Book {Title="Центр тяжести", ImagePath="centre.jpg", Description="Описание4" },
            new Book {Title="123456", ImagePath="centre.jpg", Description="Описание4" },
            };
        }
    }
}
