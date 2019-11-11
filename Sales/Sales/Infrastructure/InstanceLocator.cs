using System;
using System.Collections.Generic;
using System.Text;
using Sales.ViewModels;

namespace Sales.Infrastructure
{
    class InstanceLocator
    {
        #region Properties
        public MainViewModels Main { 
            get;
            set;
        }

        #endregion
        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModels();
        }

        #endregion
    }
}
