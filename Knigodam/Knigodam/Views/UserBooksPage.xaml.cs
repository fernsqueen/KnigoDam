using Knigodam.Models;
using Knigodam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Knigodam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserBooksPage : ContentPage
    {
        public List<Book> Books { get; set; }
        public UserBooksPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            Books = new List<Book>
        {
            new Book {Title="Тобол. Мало избранных", ImagePath="tobol.jpg", Description="Описание1" },
            new Book {Title="Python для детей", ImagePath="python.jpg", Description="Описание2" },
        };
            this.BindingContext = this;
        }

        async private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var book = e.Item as Book;
            EditBookPage page = new EditBookPage(book);
            var lv = sender as ListView;
            //lv.IsEnabled = false;
            lv.SelectedItem = null;
            await Navigation.PushAsync(page);
        }
    }
}