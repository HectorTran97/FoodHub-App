using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodHub.Model
{
    public class UserRating
    {
        [JsonProperty("aggregate_rating")]
        public string AggregateRating { get; set; }

        [JsonProperty("rating_text")]
        public string RatingText { get; set; }

        [JsonProperty("votes")]
        public string Votes { get; set; }
    }
}
