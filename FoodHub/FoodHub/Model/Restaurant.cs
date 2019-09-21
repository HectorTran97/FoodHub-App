using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FoodHub.Model
{
    class Restaurant
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("featured_image")]
        public Uri ImageURL { get; set; }

        [JsonProperty("average_cost_for_two")]
        public string AverageCost { get; set; }

        [JsonProperty("location")]
        public Location RestaurantLocation { get; set; }

        [JsonProperty("user_rating")]
        public UserRating Rating { get; set; }

        public Restaurant()
        {

        }
    }
}
