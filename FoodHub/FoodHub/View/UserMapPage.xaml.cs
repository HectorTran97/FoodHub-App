using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHub.ViewModel;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace FoodHub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMapPage : ContentPage
    {
        //        public UserMapPage()
        //        {
        //            InitializeComponent();
        //            BindingContext = new UserMapViewModel();
        //            MyMap.MoveToRegion(
        //            MapSpan.FromCenterAndRadius(
        //            new Position(-37.95939, 145.0172917), Distance.FromMiles(10)));

        //;

        //        }
        readonly UserMapViewModel userMapViewModel;
        public UserMapPage(string name, double latitude, double longtitude)
        {
            userMapViewModel = new UserMapViewModel(name, latitude, longtitude);
            InitializeComponent();
            BindingContext = userMapViewModel;
            MyMap.MoveToRegion(
            MapSpan.FromCenterAndRadius(
            new Position(-37.95939, 145.0172917), Distance.FromMiles(10)));
        }
    }
}