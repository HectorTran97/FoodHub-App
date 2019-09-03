using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FoodHub.Model;
using Newtonsoft.Json;

namespace FoodHub.Data
{
    class RestaurantManager
    {
        HttpClient client = new HttpClient();
        List<Restaurant> restaurantList = null;

        decimal latitude;
        decimal longitude;
        const string apiKey = "6e085047a299af09192196321ca6b2ce";

        public async Task<List<Restaurant>> FetchRestaurantAsync()
        {
            string url;
            url = getURL(latitude, longitude);
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    restaurantList = JsonConvert.DeserializeObject<List<Restaurant>>(content);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"       Error{0} ", e.Message);
            }
            return restaurantList;
        }

        public string getURL(decimal lat, decimal longtitude)
        {
            string url;
            url = "https://developers.zomato.com/api/v2.1/geocode?lat=" + lat.ToString() + "&lon=" + longitude.ToString() + apiKey;
            return url;
        }
        
    }
}
