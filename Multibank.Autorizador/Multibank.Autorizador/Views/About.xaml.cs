using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Multibank.Autorizador.ViewModels;

namespace Multibank.Autorizador.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        private AboutViewModel viewModel;

        public About()
        {
            InitializeComponent();

            BindingContext = viewModel = new AboutViewModel();
            viewModel.Navigation = Navigation;
        }
    }
}