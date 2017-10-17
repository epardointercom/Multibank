using System;
using System.Windows.Input;
using Xamarin.Forms;
using Multibank.Autorizador.Views;

namespace Multibank.Autorizador.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            MultibankCommand = new Command(Multibank);
        }

        #region Commands

        public INavigation Navigation { get; set; }
        public ICommand MultibankCommand { get; set; }

        #endregion

        public async void Multibank()
        {
            IsBusy = true;
            Title = string.Empty;
            try
            {
                Device.OpenUri(new Uri("https://www.multibank.com.co/"));
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Quiénes somos", $"{ex.Message}", "Ok");
            }
        }
    }
}
