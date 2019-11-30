using Sales.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Sales.ViewModels
{
    public class LandViewModels :BaseViewModel
    {
        #region Attributes

        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> language;
        #endregion

        #region Property
        public Land Land
        {
            get;
            set;
        }

        public ObservableCollection<Border> Borders
        {
            get { return borders; }
            set { this.SetValue(ref this.borders, value); }

        }

        public ObservableCollection<Currency> Currencies
        {
            get { return currencies; }
            set { this.SetValue(ref this.currencies, value); }

        }

        public ObservableCollection<Language> Language
        {
            get { return language; }
            set { this.SetValue(ref this.language, value); }

        }
        #endregion

        #region Constructores
        public LandViewModels(Land land)
        {
            this.Land = land;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.Language = new ObservableCollection<Language>(this.Land.Languages);
        }

        #endregion
        #region Methods
        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModels.GetInstance().LandsList.
                                        Where(l => l.Alpha3Code == border).
                                        FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name,
                    });
                }
            }
        }
        #endregion

    }
}
