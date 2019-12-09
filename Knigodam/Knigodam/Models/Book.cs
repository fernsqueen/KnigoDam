using System;
using System.Collections.Generic;
using System.Text;

namespace Knigodam.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }      
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int UserId { get; set; }
    }
}
