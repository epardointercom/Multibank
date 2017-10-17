using System;
using System.Windows.Input;
using Xamarin.Forms;
using Multibank.Autorizador.Views;

namespace Multibank.Autorizador.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            TermsCommand = new Command(Terms);
            AboutCommand = new Command(About);
            OfficesCommand = new Command(Offices);
            ContactCommand = new Command(Contact);
        }

        #region Commands

        public INavigation Navigation { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand TermsCommand { get; set; }
        public ICommand AboutCommand { get; set; }
        public ICommand ContactCommand { get; set; }
        public ICommand OfficesCommand { get; set; }        

        #endregion

        #region Properties

        string agreement;
        public string Agreement
        {
            get { return agreement; }
            set { SetProperty(ref agreement, value); }
        }

        string userName;
        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }

        string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        #endregion

        public async void Login()
        {
            IsBusy = true;
            Title = string.Empty;
            try
            {
                if(!string.IsNullOrEmpty(Agreement))
                {
                    if (!string.IsNullOrEmpty(UserName))
                    {
                        if (!string.IsNullOrEmpty(Password))
                        {
                            var result = await DataService.Authentication(UserName, Password);
                            if (result.Success)
                            {
                                if (result.Data)
                                {
                                    await Navigation.PushModalAsync(new NavigationPage(new Authorizer()));
                                }
                                else
                                {
                                    Message = result.Error;
                                }
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Error de autenticación", result.Error, "Ok");
                                Message = "Error interno de autenticación";
                            }
                            IsBusy = false;
                        }
                        else
                        {
                            IsBusy = false;
                            Message = "Ingrese la contraseña";
                        }
                    }
                    else
                    {
                        IsBusy = false;
                        Message = "Ingrese el usuario";
                    }
                }
                else
                {
                    IsBusy = false;
                    Message = "Ingrese el número de convenio de la empresa";
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Error de autenticación", $"{ex.Message}", "Ok");
            }
        }

        public async void About()
        {
            IsBusy = true;
            Title = string.Empty;
            try
            {
                await Navigation.PushModalAsync(new NavigationPage(new About()));
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Quiénes somos", $"{ex.Message}", "Ok");
            }
        }

        public async void Offices()
        {
            IsBusy = true;
            Title = string.Empty;
            try
            {
                await Navigation.PushModalAsync(new NavigationPage(new Offices()));
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Términos y condiciones", $"{ex.Message}", "Ok");
            }
        }

        public async void Contact()
        {
            IsBusy = true;
            Title = string.Empty;
            try
            {

                var result = await DataService.ContactInfo();

                if (result.Success)
                {
                    await Navigation.PushModalAsync(new NavigationPage(new Contact(result.Data)));
                    IsBusy = false;
                }
                else
                {
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("Contáctenos", $"{result.Error}", "Ok");
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Contáctenos", $"{ex.Message}", "Ok");
            }
        }

        public async void Terms()
        {
            IsBusy = true;
            Title = string.Empty;
            try
            {
                await Navigation.PushModalAsync(new NavigationPage(new Terms()));
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Términos y condiciones", $"{ex.Message}", "Ok");
            }
        }
    }
}
