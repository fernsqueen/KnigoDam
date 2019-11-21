using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Knigodam.Models;

namespace Knigodam.Services.Fakes
{
    class FakeManageBooksService : IBooksManager
    {
        public Task DeleteBook(Book Book)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetMyBooks(string sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
