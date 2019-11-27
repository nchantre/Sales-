using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Sales.Models;
using Sales.Views;
using Xamarin.Forms;

namespace Sales.ViewModels
{
     public class LandItemViewModel : Land
    {
        #region Command
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);
            }
          
        }

        private async void SelectLand()
        {
            MainViewModels.GetInstance().Land = new LandViewModels(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }

        #endregion



    }
}
