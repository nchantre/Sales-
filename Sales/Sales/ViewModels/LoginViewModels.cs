using System;
using System.Collections.Generic;
using System.Text;
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
        public Command btnlogin { get; set; }
        #endregion
        #region Contructores
        public LoginViewModels()
        {
            this.ddlrecordar = true;

        }

        #endregion
    }
}
