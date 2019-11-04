using DocumentFormat.OpenXml.Drawing;
using Knigodam.Models;
using Knigodam.Services;
using Knigodam.Services.Fakes;
using Knigodam.Views;
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
        static void RegisterMyService()
        {
            Service<IBooksService>.RegisterService(new FakeBooksService());
        }

        public List<Book> Books { get; set; }

        public MainPage()
        {
            InitializeComponent();

            RegisterMyService();

            NavigationPage.SetHasNavigationBar(this, false);

            Books=new List<Book>{
            new Book { Title = "Тобол. Мало избранных", ImagePath = "tobol.jpg", Description = "Описание1" },
            new Book { Title = "Python для детей", ImagePath = "python.jpg", Description = "Описание2" },
            new Book { Title = "Тонкое искусство пофигизма", ImagePath = "pofigizm.jpg", Description = "Описание3" },
            new Book { Title = "Центр тяжести", ImagePath = "centre.jpg", Description = "Описание4" },
            new Book { Title = "123456", ImagePath = "centre.jpg", Description = "Описание4" }
            };


            //Books = GetBooks();

            this.BindingContext = this;
        }

        async Task<List<Book>> GetBooks()
        {
            var books = await Service<IBooksService>.GetInstance().GetBooks();
            return books;
        }



        async private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var book = e.Item as Book;
            BookPage page = new BookPage(book);
            var lv = sender as ListView;
            //lv.IsEnabled = false;
            lv.SelectedItem = null;
            await Navigation.PushAsync(page);
        }

        async private void AddBookButton_Clicked(object sender, EventArgs e)
        {
            AddBookPage page = new AddBookPage();
            await Navigation.PushAsync(page);
        }

        async private void DMButton_Clicked(object sender, EventArgs e)
        {
            DMPage page = new DMPage();
            await Navigation.PushAsync(page);
        }

        async private void EditButton_Clicked(object sender, EventArgs e)
        {
            UserBooksPage page = new UserBooksPage();
            await Navigation.PushAsync(page);
        }

        async private void advSearch_Clicked(object sender, EventArgs e)
        {
            AdvanceSearchPage page = new AdvanceSearchPage();
            await Navigation.PushAsync(page);
        }
    }
}
