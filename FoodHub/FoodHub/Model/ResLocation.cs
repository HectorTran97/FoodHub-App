using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
namespace FoodHub.Model
{
    public class ResLocation
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public Position RestaurantPosition { get; set; }
        public ResLocation()
        {
        }
    }
}
