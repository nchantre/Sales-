using DocumentFormat.OpenXml.Wordprocessing;
using Sales.Models;
using Sales.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

using System.Text;
using Xamarin.Forms;

namespace Sales.ViewModels
{
    public class LandsViewModels : BaseViewModel
    {
        #region Service

        private ApiService apiService;
        #endregion
        #region Attributes
        private ObservableCollection<Land> lands;
        #endregion

        #region  Properties
        public ObservableCollection<Land> Lands
        {
            get { return lands; }
            set { SetValue(ref this.lands, value); }

        }
        #endregion

        #region Constructors
        public LandsViewModels()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }


        #endregion

        #region Methods
        private async void LoadLands()
        {

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;

            }
            var response = await this.apiService.GetList<Land>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;

            }

            var list = (List < Land > )response.Result;
            this.Lands = new ObservableCollection<Land>(list);
            
        }
        #endregion
    }
}
