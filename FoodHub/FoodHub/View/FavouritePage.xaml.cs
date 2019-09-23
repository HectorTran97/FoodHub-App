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
    public partial class FavouritePage : ContentPage
    {
        private readonly FavouriteViewModel favRestaurantViewModel;
        public FavouritePage()
        {
            favRestaurantViewModel = new FavouriteViewModel();
            InitializeComponent();
            BindingContext = favRestaurantViewModel;
        }

        public async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var resDetails = e.Item as Restaurant;
            await Navigation.PushAsync(new MenuPage(resDetails.ID.ToString(), resDetails.ImageURL.ToString(), resDetails.Name, resDetails.Rating.AggregateRating, resDetails.AverageCost));
        }
    }
}