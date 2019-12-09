using System;
using System.Collections.Generic;
using System.Text;

namespace Knigodam.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public List<Book> Books { get; set; }
    }
}
