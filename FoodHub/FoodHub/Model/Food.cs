using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodHub.Model
{
    public class Food
    {
        // Properties to get Foodname, Foodimage, Fooddescription, Foodprice and Menuid
        [JsonProperty("Name")]
        public string FoodName { get; set; }

        [JsonProperty("Image")]
        public Uri FoodImage { get; set; }

        [JsonProperty("Description")]
        public string FoodDescription { get; set; }

        [JsonProperty("Price")]
        public string FoodPrice { get; set; }

        [JsonProperty("MenuId")]
        public string MenuId { get; set; }

        public Food()
        {

        }
    }
}
