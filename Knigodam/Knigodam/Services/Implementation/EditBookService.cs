using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services.Implementation
{
    class EditBookService : IEditBookService
    {
        private string uri_delete = "http://10.155.58.157/api/v1/books/";

        public async Task DeleteBook(int id)
        {
            //{id:\d+}/edit/status={status}
            var uri_id = uri_delete + id.ToString();

            var client = new HttpClient();
            await client.DeleteAsync(uri_id);
        }

        public async Task EditBookStatus(int id, string status)
        {
            var uri_id = uri_delete + id.ToString() + "/edit/status=" + status;
            var client = new HttpClient();
            await client.GetAsync(uri_id);
        }
    }
}
