using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Sales.Views;
using System.Windows.Input;
using Xamarin.Forms;
using Sales.Services;

namespace Sales.ViewModels
{
    public class LoginViewModels : BaseViewModel
    {
        #region Services
        private ApiService apiService;

        #endregion

        #region Attributes
        private string txtPassword;
        private string txtEmail;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Propiedades
        public string TxtEmail
        {
            get { return txtEmail; }
            set { SetValue(ref this.txtEmail, value); }
            
        }
        public string TxtPassword 
        {
            get { return txtPassword; }
            set { SetValue(ref this.txtPassword, value); }
        }
        public bool IsRunning 
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
           
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        public bool Ddlrecordar { get; set; }

        #endregion
        #region Commandos
        public ICommand btnlogin
        {
            get
            {
                return new RelayCommand(login);
            }
             
        }

        private async void login()
        {
            if (string.IsNullOrEmpty(this.TxtEmail))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");
                return;

            }
            //################################################
            if (string.IsNullOrEmpty(this.TxtPassword))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Password",
                    "Accept");
                return;


            }
            //##########################################################
             if (this.TxtEmail !="uno" || this.TxtPassword != "1234")
             {
                 await Application.Current.MainPage.DisplayAlert(
                     "Error",
                     "Email or Password incorrec.",
                     "Accept");
                   this.TxtPassword = string.Empty;
                   this.TxtEmail= string.Empty;
                 return;


             }

            /* var connection = await this.apiService.CheckConnection();
             if (!connection.IsSuccess)
             {
                 await Application.Current.MainPage.DisplayAlert(
                      "Error",
                      connection.Message,
                      "Accept");             
                 return;
             }
             var token = await this.apiService.GetToken(
                 "https://landsapi1.azurewebsites.net/",
                 this.TxtEmail,
                 this.TxtPassword);
             if (token == null)
             {
                 await Application.Current.MainPage.DisplayAlert(
                      "Error",
                      "Something was wrong",
                      "Accept");
                 return;


             }
             if (string.IsNullOrEmpty(token.AccessToken))
             {
                 await Application.Current.MainPage.DisplayAlert(
                      "Error",
                      token.ErrorDescription,
                      "Accept");
                 return;


             }*/

            var mainViewModel = MainViewModels.GetInstance();

            //mainViewModel.Token = token;
            // MainViewModels.GetInstance().Lands = new LandsViewModels();
            mainViewModel.Lands = new LandsViewModels();
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroFincasPage());
            this.TxtPassword = string.Empty;
            this.TxtEmail = string.Empty;






        }
        #endregion
        #region Contructores
        public LoginViewModels()
        {
            this.apiService = new ApiService();
            this.IsEnabled = true;
            this.Ddlrecordar = true;
           

        }

        #endregion
    }
}
