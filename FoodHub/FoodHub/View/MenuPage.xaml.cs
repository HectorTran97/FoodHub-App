using FoodHub.Model;
using FoodHub.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodHub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        readonly MenuViewModel menuViewModel;
        //public MenuPage(string resID, string resImage, string resName, string resRating, string resAverageCost)
        //{
        //    menuViewModel = new MenuViewModel(resID, resImage, resName, resRating, resAverageCost);
        //    InitializeComponent();
        //    BindingContext = menuViewModel;
        //}
        private string name;
        private double latitude;
        private double longtitude;
        public MenuPage(string resID, string resImage, string resName, string ResRating, string ResAverageCost, double resLatittude, double resLongtitude)
        {
            name = resName;
            latitude = resLatittude;
            longtitude = resLongtitude;
            menuViewModel = new MenuViewModel(resID, resImage, resName, ResRating, ResAverageCost);
            InitializeComponent();
            BindingContext = menuViewModel;
        }

        public async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var foodDetail = e.Item as Food;
            await Navigation.PushAsync(new OrderPage(foodDetail.MenuId, foodDetail.FoodName, foodDetail.FoodImage, foodDetail.FoodDescription));
        }

        public async void GetLocationOnMap(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserMapPage(name, latitude, longtitude));

        }
    }
}