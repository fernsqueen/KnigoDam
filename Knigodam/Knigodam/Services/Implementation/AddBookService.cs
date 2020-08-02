using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Knigodam.Models;

namespace Knigodam.Services.Implementation
{
    class AddBookService : IAddBookService
    {
        private string uri = "http://10.155.58.157/api/v1/books/add%";
        public async Task<bool> AddBook(Book book)
        {
            //var fB = File.ReadAllBytes(book.ImagePath);
            //string encodedFile = Convert.ToBase64String(fB);
            var _uri = uri + "title=" + book.Title + "&description=" + book.Description +
                "&user_id=" + book.UserId.ToString() + "&publishing_house=" + book.PublishingHouse +
                "&author=" + book.Author + "&year=" + book.Year.ToString() +
                "&language=" + book.Language;
            var client = new HttpClient();
            var result = await client.GetAsync(_uri);
            return true;
        }
    }
}
