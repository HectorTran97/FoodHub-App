using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodHub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMapPage : ContentPage
    {
        public UserMapPage()
        {
            InitializeComponent();
        }
        string name = "hungry jack";
       private async void OpenMapButtonClicked(object sender, EventArgs e)
        {
            await Map.OpenAsync(-37.963043, 145.145009, new MapLaunchOptions { Name = name, NavigationMode = NavigationMode.None });
      
        }
    }
}