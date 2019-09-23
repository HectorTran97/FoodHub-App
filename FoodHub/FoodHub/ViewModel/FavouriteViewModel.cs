using FoodHub.Data;
using FoodHub.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.ViewModel
{
    class FavouriteViewModel : INotifyPropertyChanged
    {
        readonly FavouriteManager myFavRestaurantManager = new FavouriteManager();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Restaurant> myFavRestaurantList;
        public ObservableCollection<Restaurant> MyFavRestaurantList
        {
            get { return myFavRestaurantList; }
            set
            {
                myFavRestaurantList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyRestaurantList"));
            }
        }

        public async Task FetchDataAsync()
        {
            var list = await myFavRestaurantManager.FetchFavAsync(GetRestaurantIDs());
            MyFavRestaurantList = new ObservableCollection<Restaurant>(list);
        }

        // this method will be used to get id from firebase
        // now populate sample for testing
        public List<decimal> GetRestaurantIDs()
        {
            List<decimal> result = new List<decimal>();
            result.Add(16774318);
            return result;
        }

        public FavouriteViewModel()
        {
            FetchDataAsync();
        }

    }
}
