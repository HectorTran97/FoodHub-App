using FoodHub.Data;
using FoodHub.Helper;
using FoodHub.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodHub.ViewModel
{
    class RestaurantViewModel : INotifyPropertyChanged
    {
        // this is a sample data to test whether the listview shows any data
        readonly RestaurantManager myRestaurantManager = new RestaurantManager();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Restaurant> myRestaurantList;
        public RestaurantViewModel()
        {
            _ = FetchDataAsync();
        }

        public ObservableCollection<Restaurant> MyRestaurantList
        {
            get { return myRestaurantList; }
            set
            {
                myRestaurantList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyRestaurantList)));
            }
        }

        public async Task FetchDataAsync()
        {
            var list = await myRestaurantManager.FetchRestaurantAsync();
            MyRestaurantList = new ObservableCollection<Restaurant>(list);
        }

        //public Command AddFavoriteCommand => new Command(AddFavoriteCommandHandler);

        //private async void AddFavoriteCommandHandler(object obj)
        //{
        //    // Get Loged-in User info
        //    var loggedInUser = GlobalData.LogedInUser;
        //    if (loggedInUser == null)
        //    {
        //        return;
        //    }            

        //    if (!(obj is Restaurant seletedRestaurant))
        //    {
        //        return;
        //    }

        //    loggedInUser.Favorites.Add(seletedRestaurant.ID);
        //    await FireBaseHelper.UpdateUser(loggedInUser);
        //}
    }
}
