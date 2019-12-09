using Knigodam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services
{
    interface ISearchService
    {
        Task<List<BookItem>> GetSimpleSearchedBooks(string entry);
    }
}
