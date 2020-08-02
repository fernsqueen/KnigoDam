using Knigodam.Models;
using Knigodam.Services.Fakes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services.Implementation
{
    class BookItemService : IBooksItemService
    {
        private string uri = "http://10.155.58.157/api/v1/books";
        public async Task<List<BookItem>> GetBooks()
        {
            //TODO: Загрузка данных
            var client = new HttpClient();
            var result = await client.GetAsync(uri);
            var content = await result.Content.ReadAsStringAsync();

            var json_books = JsonConvert.DeserializeObject<List<booksitem>>(content);
            var books = new List<BookItem>();
            
            foreach (booksitem book in json_books)
            {
                
                string base64str = book.img;
                byte[] bytes = Convert.FromBase64String(base64str);
                string saveLocation = GetFilePath(book.id.ToString()+".jpg");
                FileStream fs = new FileStream(saveLocation, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                try
                {
                    bw.Write(bytes);
                }
                finally
                {
                    fs.Close();
                    bw.Close();
                }
                BookItem new_book = new BookItem { Id = book.id, Title = book.title, ImagePath = saveLocation };
                books.Add(new_book);
            }
            
            return books;
        }

        public async Task SaveTextAsync(string filename, string text)
        {
            string filepath = GetFilePath(filename);
            using (StreamWriter writer = File.CreateText(filepath))
            {
                await writer.WriteAsync(text);
            }
        }

        // вспомогательный метод для построения пути к файлу
        string GetFilePath(string filename)
        {
            return Path.Combine(GetDocsPath(), filename);
        }
        // получаем путь к папке MyDocuments
        string GetDocsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private class JsonItem
        {
            public List<booksitem> books { get; set; }
        }

        public class booksitem
        {
            public int id { get; set; }
            public string title { get; set; }
            public string img { get; set; }
        }

    }
}
