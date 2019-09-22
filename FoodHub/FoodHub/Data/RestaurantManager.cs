using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FoodHub.Model;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace FoodHub.Data
{
    class RestaurantManager
    {
        HttpClient client = new HttpClient();
        public List<Restaurant> restaurantList = null;

        //private double latitude;
        //private double longitude;
        /*const string url = "https://developers.zomato.com/api/v2.1/";
        const string apiKey = "749b7981ff9e98b3b0ed487c17028e6e";*/ // this one is from online (better not to use it)

        // this link and api key is for us
        const string url = "https://developers.zomato.com/api/v2.1/";
        //const string apiKey = "6658febb98bf56ff89f10b199ff9e81a";
        const string apiKey = "6e085047a299af09192196321ca6b2ce";


        public async Task<List<Restaurant>> FetchRestaurantAsync()
        {
            try
            {
                using (var httpClient = GetHttpClient(url))
                {
                    //string urlParameters = GetUrlParameter(await GetLocationAsync(1), await GetLocationAsync(2));
                    // Below use Deakin Burwood address
                    string urlParameters = GetUrlParameter(-37.847580, 145.114192);
                    //string urlParameters = $"search?entity_id=59&entity_type=city&apikey={apiKey}";
                    HttpResponseMessage response = await httpClient.GetAsync(urlParameters);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<RestaurantList>(content);
                        return ConvertToRes(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error{ex.Message}");
            }
            return restaurantList;
        }
        public string GetUrlParameter(double latitude, double longitude)
        {
            string url;
            url = $"geocode?lat={latitude}&lon={longitude}&apikey={apiKey}";
            return url;
        }
        private static HttpClient GetHttpClient(string url)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        public async Task<double> GetLocationAsync(int coordinate)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);
            try
            {
                if (location != null)
                {
                    if (coordinate == 1)
                    {
                        return location.Latitude;
                    }
                    else
                    {
                        return location.Longitude;
                    }
                }
            }
            catch (FeatureNotSupportedException)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException)
            {
                // Handle permission exception
            }
            catch (Exception)
            {
                // Unable to get location
            }
            if (coordinate == 1)
            {
                return location.Latitude;
            }
            else
            {
                return location.Longitude;
            }
        }

        private List<Restaurant> ConvertToRes(RestaurantList data)
        {
            List<Restaurant> result = new List<Restaurant>();
            for (int i = 0; i < data.Restaurants.Count; i++)
            {
                result.Add(data.Restaurants[i].Restaurant);
            }
            return result;
        }
    }
}
