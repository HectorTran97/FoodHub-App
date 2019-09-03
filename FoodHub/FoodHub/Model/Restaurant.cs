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

        /*[JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("featured_image")]
        public string ImageURL { get; set; }

        [JsonProperty("user_rating")]
        public int Rating { get; set; }

        [JsonProperty("cusines")]
        public string Type { get; set; }*/



    }
}
