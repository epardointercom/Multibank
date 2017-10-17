using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Multibank.Autorizador.ViewModels;

namespace Multibank.Autorizador.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Authorizer : ContentPage
    {
        private AuthorizerViewModel viewModel;

        public Authorizer()
        {
            InitializeComponent();

            BindingContext = viewModel = new AuthorizerViewModel();
            viewModel.Navigation = Navigation;
        }
    }
}