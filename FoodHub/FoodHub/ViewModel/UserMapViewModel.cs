using System;
using System.Collections.Generic;
using System.Text;
using FoodHub.View;
using FoodHub.Model;
using System.IO;
using System.Linq;
using Xamarin.Forms;

using Xamarin.Essentials;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

namespace FoodHub.ViewModel
{
    class UserMapViewModel: INotifyPropertyChanged
    {
        //private Location restaurantLocation;
        //public Location RestaurantLocation
        //{
        //    get;set;
        //}
        public ObservableCollection<ResLocation> RestaurantLocations
        {
            get;set;
        }
        ResLocation tempLocation = new ResLocation() { Address = "Hungry Jacks", Description = "A place to feed your hunger", RestaurantPosition = new Position(-37.8492053, 145.1071894) };
       
        public UserMapViewModel()
        {
            RestaurantLocations = new ObservableCollection<ResLocation>();
            RestaurantLocations.Add(tempLocation);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command GetDirectionCommand
        {
            get
            {
                return new Command(OpenMap);
            }
        }
        private async void OpenMap()
        {
            await Xamarin.Essentials.Map.OpenAsync(-37.8492053, 145.1071894, new MapLaunchOptions {
            Name = "Hungry Jack",
            NavigationMode = NavigationMode.None });
        }
    }
}
