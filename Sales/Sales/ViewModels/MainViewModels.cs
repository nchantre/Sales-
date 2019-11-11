using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.ViewModels
{
    public class MainViewModels
    {
        #region ViewModel
        public LoginViewModels Login
        {
            get;
            set;
        }
        #endregion
        #region Contructors
        public MainViewModels()
        {
            this.Login = new LoginViewModels();

        }



        #endregion
    }
}
