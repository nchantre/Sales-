using Sales.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.ViewModels
{
    public class MainViewModels
    {
        #region Properties
        public List<Land> LandsList 
        {
            get;
            set;
        
        }
        public TokenResponse Token
        {
            get;
            set;

        }


        #endregion

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

        public LandViewModels Land
        {
            get;
            set;
        }

        public UbicationViewModels Ubication
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
