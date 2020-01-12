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
    public partial class DMPage : ContentPage
    {
        DMPageViewModel _viewModel;
        public List<Message> Messages { get; set; }
        public DMPage(User user)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            _viewModel = new DMPageViewModel(user);

            _viewModel.MessagesListIsEmpty += BookListIsEmpty;

            _viewModel.MessagesListIsNotEmpty += BookListIsNotEmpty;


            this.BindingContext = _viewModel;
        }

        private void BookListIsNotEmpty(object sender, EventArgs e)
        {
            messageList.IsVisible = true;
            EmptyList.IsVisible = false;
        }

        private void BookListIsEmpty(object sender, EventArgs e)
        {
            messageList.IsVisible = false;
            EmptyList.IsVisible = true;
        }

        async private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}