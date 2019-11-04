using Knigodam.Models;
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
        public List<Message> Messages { get; set; }
        public DMPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            Messages = new List<Message>
        {
            new Message {Title="Тобол. Мало избранных", ImagePath="tobol.jpg", MessageText="Привет!", MessageDate ="15:34"},
            new Message {Title="Python для детей", ImagePath="python.jpg", MessageText="Спасибо большое!", MessageDate ="Mon" },
        };

            this.BindingContext = this;
        }

        async private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}