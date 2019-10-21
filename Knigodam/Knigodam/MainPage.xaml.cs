using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Knigodam
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<Book> Books { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Books = new List<Book>
        {
            new Book {Title="Тобол. Мало избранных.", ImagePath="tobol.jpg" },
            new Book {Title="Python для детей", ImagePath="python.jpg" },
            new Book {Title="Тонкое искусство пофигизма", ImagePath="pofigizm.jpg" },
            new Book {Title="Центр тяжести", ImagePath="centre.jpg" },
        };
            this.BindingContext = this;
        }



        private void OnItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
                  selected.Text = "debug";
        }

        public class Book
        {
            public string Title { get; set; }
            public string ImagePath { get; set; }
        }
    }
}
