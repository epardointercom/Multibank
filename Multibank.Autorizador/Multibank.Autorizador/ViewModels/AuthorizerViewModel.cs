using System.Windows.Input;
using Xamarin.Forms;
using Multibank.Autorizador.Views;
using Multibank.Autorizador.Models;

namespace Multibank.Autorizador.ViewModels
{
    public class AuthorizerViewModel : BaseViewModel
    {
        public AuthorizerViewModel()
        {
            LogoutCommand = new Command(Logout);
            client = Settings.CurrentUser;
        }

        #region Commands

        public INavigation Navigation { get; set; }
        public ICommand LogoutCommand { get; set; }

        #endregion

        #region Properties

        User client = null;
        public User Client
        {
            get { return client; }
            set { SetProperty(ref client, value); }
        }

        #endregion

        private async void Logout()
        {
            Settings.IsLoggedIn = false;
            await Navigation.PushAsync(new Login());
        }
    }
}
