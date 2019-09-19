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
    class RestaurantViewModel : INotifyPropertyChanged
    {
        // this is a sample data to test whether the listview shows any data
        private readonly List<Restaurant> sampleList = new List<Restaurant>(new Restaurant[] {
                new Restaurant{ ID = 1, Name = "Azure"},
                new Restaurant{ ID = 2, Name = "Watson"}
            });
        readonly RestaurantManager myRestaurantManager = new RestaurantManager();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Restaurant> myRestaurantList;
        public ObservableCollection<Restaurant> MyRestaurantList
        {
            get { return myRestaurantList; }
            set
            {
                myRestaurantList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyRestaurantList"));
            }

        }
        public async Task FetchDataAsync()
        {
            var list = await myRestaurantManager.FetchRestaurantAsync();
            MyRestaurantList = new ObservableCollection<Restaurant>(list);
        }
        public RestaurantViewModel()
        {
            _ = FetchDataAsync();
            //MyRestaurantList = new ObservableCollection<Restaurant>(sampleList);
        }
    }
}
