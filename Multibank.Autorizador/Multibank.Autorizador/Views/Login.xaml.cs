using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Multibank.Autorizador.ViewModels;

namespace Multibank.Autorizador.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private LoginViewModel viewModel;

        public Login()
        {
            InitializeComponent();
            
            BindingContext = viewModel = new LoginViewModel();
            viewModel.Navigation = Navigation;
        }
    }
}