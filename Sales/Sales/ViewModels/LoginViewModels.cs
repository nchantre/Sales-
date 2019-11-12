using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sales.ViewModels
{
    public class LoginViewModels : BaseViewModel
    {
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
            if (this.TxtEmail !="uno@gmail.com" || this.TxtPassword != "1234")
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or Password incorrec.",
                    "Accept");
                  this.TxtPassword = string.Empty;
                return;


            }



        }
        #endregion
        #region Contructores
        public LoginViewModels()
        {
            
            this.IsEnabled = true;

            this.Ddlrecordar = true;

        }

        #endregion
    }
}
