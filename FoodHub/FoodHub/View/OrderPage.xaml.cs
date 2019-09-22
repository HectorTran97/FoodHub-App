using FoodHub.ViewModel;
using Plugin.Segmented.Control;
using Plugin.Segmented.Event;
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
    public partial class OrderPage : ContentPage
    {
        readonly OrderViewModel orderViewModel;
        public OrderPage(string foodID, string foodName, Uri foodImage, string foodDescription)
        {
            orderViewModel = new OrderViewModel(foodID, foodName, foodImage, foodDescription);
            InitializeComponent();
            BindingContext = orderViewModel;
        }

        public void OnSegmentSelected(Object sender, SegmentSelectEventArgs e)
        {
            var selectedSegment = ((SegmentedControl)sender).SelectedSegment;
            orderViewModel.SelectedSegment = selectedSegment;
        }

        public async void OnClickedButton(Object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert("FoodHub Team", "Thanks for your purchase. Your order is placed.", "OK");
            await Navigation.PushAsync(new RestaurantPage());
        }
    }
}