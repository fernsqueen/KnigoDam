using System;
using System.Collections.Generic;
using System.Text;

namespace Knigodam.Models
{
    class User
    {
        public string Number { get; set; }
        public List<Book> Books { get; set; }
    }
}
