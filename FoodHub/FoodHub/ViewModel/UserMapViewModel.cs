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
    class UserMapViewModel/*INotifyPropertyChanged*/
    {
        //private Location restaurantLocation;
        //public Location RestaurantLocation
        //{
        //    get;set;
        //}
        public ObservableCollection<ResLocation> RestaurantLocations
        {
            get; set;
        }
        private string Name;
        private double Latitude;
        private double Longtitude;
        public UserMapViewModel(string name, double latittude, double longtitude)
        {
            RestaurantLocations = new ObservableCollection<ResLocation>();
            Name = name;
            Latitude = latittude;
            Longtitude = longtitude;
            ResLocation tempLocation = new ResLocation() { Address = name, Description = name, RestaurantPosition = new Position(latittude, longtitude) };
            ResLocation tempLocation1 = new ResLocation() { Address = "Zouz Cafe", Description = "Zouz Cafe", RestaurantPosition = new Position(- 37.851136, 145.1040768) };
            RestaurantLocations.Add(tempLocation);
            RestaurantLocations.Add(tempLocation1);
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        public Command GetDirectionCommand
        {
            get
            {
                return new Command(OpenMap);
            }
        }
        private async void OpenMap()
        {
            await Xamarin.Essentials.Map.OpenAsync(Latitude, Longtitude, new MapLaunchOptions
            {
                Name = Name,
                NavigationMode = NavigationMode.None
            });
        }
    }
}