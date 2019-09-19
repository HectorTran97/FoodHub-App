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
        public UserMapPage()
        {
            InitializeComponent();
            BindingContext = new UserMapViewModel();
            MyMap.MoveToRegion(
            MapSpan.FromCenterAndRadius(
            new Position(-37.95939, 145.0172917), Distance.FromMiles(10)));

            //var pin = new Pin()
            //{
            //    Type = PinType.Place,
            //    Position = new Position(-37.8492053, 145.1071894),
            //    Label = "Some Pin!"
            //};
            //MyMap.Pins.Add(pin);

        }
       // string name = "hungry jack";
       //private async void OpenMapButtonClicked(object sender, EventArgs e)
       // {
       //     await Map.OpenAsync(-37.963043, 145.145009, new MapLaunchOptions { Name = name, NavigationMode = NavigationMode.None });
      
       // }
    }
}