using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Multibank.Autorizador.ViewModels;

namespace Multibank.Autorizador.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contact : ContentPage
    {
        private ContactViewModel viewModel;

        public Contact(Models.Contact contact)
        {
            InitializeComponent();

            BindingContext = viewModel = new ContactViewModel(contact);
            viewModel.Navigation = Navigation;
        }
    }
}