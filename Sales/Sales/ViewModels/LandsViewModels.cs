﻿using DocumentFormat.OpenXml.Wordprocessing;
using Sales.Models;
using Sales.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Sales.ViewModels
{
    public class LandsViewModels : BaseViewModel
    {
        #region Service

        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string filter;      
        #endregion

        #region  Properties
        public ObservableCollection<LandItemViewModel> Lands
        {
            get { return lands; }
            set { SetValue(ref this.lands, value); }

        }
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }

        }
        public string Filter
        {
            get { return filter; }
            set
            { 
                SetValue(ref this.filter, value);
                this.Search();
            }

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
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
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

            MainViewModels.GetInstance().LandsList = (List < Land > )response.Result;
            this.Lands = new ObservableCollection<LandItemViewModel>(
            this.ToLandItemViewModel( ));
            this.IsRefreshing = false;

            

        }
        #endregion

        #region Metothods
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
           
            return MainViewModels.GetInstance().LandsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }

        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }

        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel());
            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                     this.ToLandItemViewModel().Where(
                         l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                              l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
            
        }

        #endregion
    }
}
