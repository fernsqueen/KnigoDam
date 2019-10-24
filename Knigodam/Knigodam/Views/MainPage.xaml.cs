using Knigodam.Models;
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
            new Book {Title="Тобол. Мало избранных", ImagePath="tobol.jpg", Description="Описание1" },
            new Book {Title="Python для детей", ImagePath="python.jpg", Description="Описание2" },
            new Book {Title="Тонкое искусство пофигизма", ImagePath="pofigizm.jpg", Description="Описание3" },
            new Book {Title="Центр тяжести", ImagePath="centre.jpg", Description="Описание4" },
        };
            this.BindingContext = this;
        }



        async private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            // ПРОВЕРИТЬ почему всегда один и тот же айтем передаётся даже если выбран другой
            var book = e.Item as Book;
            BookPage page = new BookPage(book);
            await Navigation.PushAsync(page);
            //page.DisplayStack();
        }


    }
}
