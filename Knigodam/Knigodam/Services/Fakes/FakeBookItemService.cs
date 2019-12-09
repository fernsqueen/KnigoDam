using Knigodam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services.Fakes
{
    class FakeBookItemService : IBooksItemService
    {
        public async Task<List<BookItem>> GetBooks()
        {
            return new List<BookItem>()
            {
            new BookItem {Id=1, Title="Тобол. Мало избранных", ImagePath="tobol.jpg"},
            new BookItem {Id=2, Title="Python для детей", ImagePath="python.jpg"},
            new BookItem {Id=3, Title="Тонкое искусство пофигизма", ImagePath="pofigizm.jpg"},
            new BookItem {Id=4, Title="Центр тяжести", ImagePath="centre.jpg"},
            new BookItem {Id=5, Title="123456", ImagePath="centre.jpg"},
            };
        }
    }
}
