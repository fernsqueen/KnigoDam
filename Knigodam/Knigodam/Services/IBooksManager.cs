using Knigodam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services
{
    interface IBooksManager
    {
        Task<List<Book>> GetMyBooks(string sessionId);

        Task DeleteBook(Book Book);
    }
}
