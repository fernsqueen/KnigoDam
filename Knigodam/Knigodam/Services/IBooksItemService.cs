using Knigodam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services.Fakes
{
    interface IBooksItemService
    {
        Task<List<BookItem>> GetBooks();
    }
}
