using Knigodam.Models;
using Knigodam.ViewModels;
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
        UserBooksPageViewModel _viesModel;
        public UserBooksPage(User user)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            _viesModel = new UserBooksPageViewModel(user);

            this.BindingContext = _viesModel;
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