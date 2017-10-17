using System;
using System.Windows.Input;
using Xamarin.Forms;
using Multibank.Autorizador.Models;

namespace Multibank.Autorizador.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public ContactViewModel(Contact contact)
        {
            CallButtonCommand = new Command<string>(CallButton);
            localNumber = contact.LocalNumber;
            nationalNumber = contact.NationalNumber;
        }

        #region Commands

        public INavigation Navigation { get; set; }
        public ICommand CallButtonCommand { get; set; }

        #endregion

        #region Properties

        string localNumber;
        public string LocalNumber
        {
            get { return localNumber; }
            set { SetProperty(ref localNumber, value); }
        }

        string nationalNumber;
        public string NationalNumber
        {
            get { return nationalNumber; }
            set { SetProperty(ref nationalNumber, value); }
        }

        #endregion

        public async void CallButton(string number)
        {
            IsBusy = true;
            Title = string.Empty;
            try
            {
                Device.OpenUri(new Uri($"tel:{number}"));
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
