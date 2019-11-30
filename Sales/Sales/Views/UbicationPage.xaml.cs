using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sales.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicationPage : ContentPage
    {
        public UbicationPage()
        {
            InitializeComponent();
            //MapView.MoveToRegion(
            //    MapSpan.FromCenterAndRadius(
            //        new Position(37, -122), Distance.FromMiles(1)));
        }

       
    }
  
}