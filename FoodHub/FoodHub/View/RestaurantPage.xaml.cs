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
    public partial class RestaurantPage : ContentPage
    {
        public RestaurantPage()
        {
            InitializeComponent();
            BindingContext = new RestaurantViewModel();
        }

        // this method sends the Restaurant object of the item that is clicked in the listView
        public async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var resDetails = e.Item as Restaurant;
            await Navigation.PushAsync(new RestaurantDetailsPage(resDetails.ID, resDetails.Name));
        }
    }
}