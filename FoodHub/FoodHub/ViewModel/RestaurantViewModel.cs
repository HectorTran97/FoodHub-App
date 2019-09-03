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
        RestaurantManager myRestaurantManager = new RestaurantManager();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Restaurant> myRestaurantList;
        public ObservableCollection<Restaurant> MyRestaurantList
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
        /*public async Task FetchDataAsync()
        {
            var list = await myRestaurantManager.GetAsync();
            MyRestaurantList = new ObservableCollection<Restaurant>(list);
        }*/
        public RestaurantViewModel()
        {
            //FetchDataAsync();
        }





    }
}
