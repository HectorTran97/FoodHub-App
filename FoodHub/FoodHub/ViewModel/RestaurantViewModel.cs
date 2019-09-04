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
        List<Restaurant> sampleList = new List<Restaurant>(new Restaurant[] {
                new Restaurant{ ID = 1, Name = "Azure"},
                new Restaurant{ ID = 2, Name = "Watson"}
            });

        RestaurantManager myRestaurantManager = new RestaurantManager();
        public event PropertyChangedEventHandler PropertyChanged;
        private RestaurantList myRestaurantList;
        public RestaurantList MyRestaurantList
        {
            get { return myRestaurantList; }
            set
            {
                myRestaurantList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyRestaurantList"));
                }
            }

        }
        public async Task FetchDataAsync()
        {
            var list = await myRestaurantManager.FetchRestaurantAsync();
            MyRestaurantList = list;
        }
        public RestaurantViewModel()
        {
            FetchDataAsync();
            //MyRestaurantList = new ObservableCollection<Restaurant>(sampleList);
        }



    }
}
