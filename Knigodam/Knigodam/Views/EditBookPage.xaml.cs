using Knigodam.Models;
using Knigodam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Knigodam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBookPage : ContentPage
    {
        EditBookViewModel _viewModel;

        public EditBookPage(Book selectedBook)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = _viewModel = new EditBookViewModel(selectedBook);
        }

        async private void ChangeStatus_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Knigodam", "Если ваша книга уже забронирована — " +
                "поставьте статус «Ожидание». Если вы отдали книгу — удалите её. " +
                "Статус книги по умолчанию «Свободна», так её сможет увидеть любой пользователь.", "OK");
            var action = await DisplayActionSheet("Изменить статус", "Отмена", null, "Ожидание", "Свободна");
            _viewModel.Edit(action);
            await DisplayAlert("Knigodam", "Статус изменён", "OK");
            _viewModel.Status = action;
        }

        public event EventHandler BookListIsUpdated;

        async private void Delete_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Knigodam", "Вы действительно хотите удалить книгу?", "Да", "Нет");
            if (result)
            {
                _viewModel.Delete();
                await DisplayAlert("Knigodam", "Книга удалена", "OK");
                BookListIsUpdated?.Invoke(this, null);
                await Navigation.PopAsync();
            }

        }
    }
}