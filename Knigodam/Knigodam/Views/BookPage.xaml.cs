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

            NavigationPage.SetHasNavigationBar(this, false);

            

            StartChat.Clicked += new EventHandler(Button_Click);
            BindingContext = _viewModel = new BookPageViewModel(selectedBook);
            _viewModel.OnBookSetted += BookSettedConfig;
        }

        private void BookSettedConfig(object sender, EventArgs e)
        {
            if (_viewModel.Description == "None")
            {
                //InfoGrid.RowDefinitions[0].Height = 0;
                //author_l1.IsVisible = false;
                _viewModel.Description = "";
            }
            if (_viewModel.Author == "None")
            {
                //InfoGrid.RowDefinitions[0].Height = 0;
                //author_l1.IsVisible = false;
                author_l2.IsVisible = false;
            }
            if (_viewModel.Year == 0)
            {
                //InfoGrid.RowDefinitions[1].Height = 0;
                //year_l1.IsVisible = false;
                year_l2.IsVisible = false;
            }
            if (_viewModel.Publisher == "None")
            {
                //InfoGrid.RowDefinitions[2].Height = 0;
                //publ_l1.IsVisible = false;
                publ_l2.IsVisible = false;
            }
            if (_viewModel.Language == "None")
            {
                //InfoGrid.RowDefinitions[3].Height = 0;
                //lang_l1.IsVisible = false;
                lang_l2.IsVisible = false;
            }
            
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            // Переход на чат
            await _viewModel.SendMessage(message.Text);
        }
    }
}