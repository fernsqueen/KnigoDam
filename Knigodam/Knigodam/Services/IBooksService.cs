using Knigodam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services
{
    interface IBooksService
    {
        Task<List<Book>> GetBooks();
    }
}
