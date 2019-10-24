using Knigodam.Models;
using Knigodam.ViewModels;
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
    public partial class BookPage : ContentPage
    {
        BookPageViewModel _viewModel;

        public BookPage(Book selectedBook)
        {
            InitializeComponent();
            StartChat.Clicked += new EventHandler(Button_Click);
            BindingContext = _viewModel = new BookPageViewModel(selectedBook);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Переход на чат
            debug.Text = "Кнопка определённо работает";
        }
    }
}