using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sales.ViewModels
{
    public class LoginViewModels
    {
        #region Propiedades
        public string txtEmail { get; set; }
        public string txtPassword { get; set; }
        public bool IsRunning { get; set; }
        public bool ddlrecordar { get; set; }

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
            if (string.IsNullOrEmpty(this.txtEmail))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");
                return;

            }

            if (string.IsNullOrEmpty(this.txtPassword))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Password",
                    "Accept");
                return;


            }



        }
        #endregion
        #region Contructores
        public LoginViewModels()
        {
            this.ddlrecordar = true;

        }

        #endregion
    }
}
