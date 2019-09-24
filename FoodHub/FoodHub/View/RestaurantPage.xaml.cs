using FoodHub.Data;
using FoodHub.Helper;
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
        private readonly RestaurantViewModel restaurantViewModel;
        
        public RestaurantPage()
        {
            restaurantViewModel = new RestaurantViewModel();
            InitializeComponent();
            BindingContext = restaurantViewModel;            
        }

        // this method sends the Restaurant object of the item that is clicked in the listView
        async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var resDetails = e.Item as Restaurant;
            await Navigation.PushAsync(new MenuPage(resDetails.ID.ToString(), resDetails.ImageURL.ToString(), resDetails.Name, resDetails.Rating.AggregateRating, resDetails.AverageCost));
        }

        // search method 
        /*
         * takes text type in search bar and compare with the restaurant name with myRestaurantList list in our view model
         * show the matched name on the screen
         */
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = BindingContext as RestaurantViewModel;
            // refresh the list in custom listview
            RestaurantCusListView.BeginRefresh();

            if (String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                RestaurantCusListView.ItemsSource = vm.MyRestaurantList;
            }
            else
            {
                RestaurantCusListView.ItemsSource = vm.MyRestaurantList.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            }
            RestaurantCusListView.EndRefresh();

        }

    }
}