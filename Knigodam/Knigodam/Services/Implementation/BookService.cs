using Knigodam.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services.Implementation
{
    class BookService : IBookService
    {
        private string uri = "http://192.168.0.101/api/v1/books/";
        public async Task<Book> GetBook(int id)
        {
            var uri_id = uri + id.ToString(); 

            var client = new HttpClient();
            var result = await client.GetAsync(uri_id);
            var content = await result.Content.ReadAsStringAsync();

            var json_books = JsonConvert.DeserializeObject<RootObject>(content);
            var books = new List<BookItem>();


            return new Book
            {
                Id = json_books.id,
                Description = json_books.description,
                Title = json_books.title,
                UserId = json_books.user_id,
                PublishingHouse = json_books.publishing_house,
                Author = json_books.author,
                Year = json_books.year,
                Status = json_books.status,
                Language = json_books.language
            };

        }

        public class RootObject
        {
            public int id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string img { get; set; }
            public int user_id { get; set; }
            public string publishing_house { get; set; }
            public string author { get; set; }
            public int year { get; set; }
            public string status { get; set; }
            public string language { get; set; }
        }
    }
}
