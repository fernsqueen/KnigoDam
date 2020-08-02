using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Knigodam.Models;
using Newtonsoft.Json;

namespace Knigodam.Services.Implementation
{
    class MessagesService : IMessagesService
    {
        private string uri = "http://10.155.58.157/api/v1/messages/";
        public async Task<List<Message>> GetMessages(int userId)
        {
            //TODO: Загрузка данных
            var _uri = uri + userId.ToString();
            var client = new HttpClient();
            var result = await client.GetAsync(_uri);
            var content = await result.Content.ReadAsStringAsync();

            var json_message = JsonConvert.DeserializeObject<List<message_item>>(content);
            var messages = new List<Message>();

            foreach (message_item message in json_message)
            {

                string base64str = message.img;
                byte[] bytes = Convert.FromBase64String(base64str);
                string saveLocation = GetFilePath(json_message.IndexOf(message).ToString() + message.title.Substring(0,4) + ".jpg");
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
                Message new_message = new Message { Title = message.title, ImagePath = saveLocation, MessageText = message.text };
                messages.Add(new_message);
            }

            return messages;
        }

        private string uri_send = "http://10.155.58.157/api/v1/messages/send%text=";

        public async Task<bool> SendMessage(Book book, string message)
        {
            var _uri_send = uri_send + message + "&user_id=" +
                book.UserId.ToString() + "&book_id=" + book.Id.ToString();
            var client = new HttpClient();
            var result = await client.GetAsync(_uri_send);
            return true;
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

        public class message_item
        {
            public string text { get; set; }
            public string title { get; set; }
            public string img { get; set; }
        }
    }
}
