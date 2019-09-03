using FoodHub.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodHub.Data
{
    class RestaurantList
    {
        [JsonProperty("nearby_restaurants")]
        public Restaurant[] Restaurants { get; set; }
    }
}
