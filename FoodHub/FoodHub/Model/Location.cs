using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodHub.Model
{
    class Location
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        public Location()
        {

        }
    }
}
