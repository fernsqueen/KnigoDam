using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knigodam.Services
{
    interface IEditBookService
    {
        Task DeleteBook(int id);
        Task EditBookStatus(int id, string status);
    }
}
