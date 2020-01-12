using Knigodam.Models;
using Knigodam.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class AddBookPage : ContentPage
    {
        AddBookPageViewModel _viewModel;
        public AddBookPage(User user)
        {
            InitializeComponent();
            //CrossCurrentActivity.Current.Init(this, bundle);
            _viewModel = new AddBookPageViewModel();
            _viewModel.User_ = user;
            BindingContext = _viewModel;
        }

        public event EventHandler BookListIsUpdated;

        private async void SubmitBook_Clicked(object sender, EventArgs e)
        {
            /*
            Image img = new Image(); 
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                
                MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                img.Source = ImageSource.FromFile(photo.Path);
            }
            */
            if (Title.Text == null)
            {
                await DisplayAlert("Knigodam", "Название не может быть пустым", "ОК");
            }
            else
            {
                string _description, _author, _publishing_house, _language;
                int _year;
                if (Description.Text == null) _description = "None";
                else _description = Description.Text;
                if (Autor.Text == null) _author = "None";
                else _author = Autor.Text;
                if (Publisher.Text == null) _publishing_house = "None";
                else _publishing_house = Autor.Text;
                if (Language.Text == null) _language = "None";
                else _language = Autor.Text;
                if (Year.Text == null) _year = 0;
                else _year = int.Parse(Year.Text);

                _viewModel.book = new Book
                {
                    Title = Title.Text,
                    Description = _description,
                    UserId = _viewModel.user.Id,
                    Author = _author,
                    PublishingHouse = _publishing_house,
                    Language = _language,
                    Year = _year
                };
                _viewModel.AddBook();
                await DisplayAlert("Knigodam", "Книга добавлена!", "ОК");
                BookListIsUpdated?.Invoke(this, null);
                await Navigation.PopAsync();
            }

        }
    }
}