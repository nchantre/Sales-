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
        public LandsViewModels Lands
        {
            get;
            set;
        }
        #endregion
        #region Contructors
        public MainViewModels()
        {
            instance = this;
            this.Login = new LoginViewModels();

        }
        #endregion
        #region Singleton
        private static MainViewModels instance;

        public static MainViewModels GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModels();
            }

            return instance;
        }
        #endregion
    }
}
