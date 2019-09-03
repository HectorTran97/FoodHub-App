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

namespace FoodHub.Data
{
    class RestaurantManager
    {
        HttpClient client = new HttpClient();
        RestaurantList restaurantList = null;

        private double latitude;
        private double longitude;
        const string url = "https://developers.zomato.com/api/v2.1/";
        const string apiKey = "6e085047a299af09192196321ca6b2ce";


        /*public async Task<List<Restaurant>> FetchRestaurantAsync()
        {
            string url;
            url = getURL(-37.847961, 145.114879);
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
            Console.WriteLine(restaurantList);
            return restaurantList;
        }*/

        private static HttpClient GetHttpClient(string url)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
        public string GetUrlParameter(double lat, double longtitude)
        {
            string url;
            url = $"geocode?lat={lat}&lon={longitude}&apikey={apiKey}";
            return url;
        }

        public RestaurantList GetRestaurantList()
        {
            string urlParameter = GetUrlParameter(-37.847961, 145.114879);
            var response = RunAsync<RestaurantList>(url, urlParameter).GetAwaiter().GetResult();
            restaurantList = response;
            return restaurantList;
        }

        private static async Task<T> GetAsync<T>(string url, string urlParameters)
        {
            try
            {
                using(var httpClient = GetHttpClient(url))
                {
                    HttpResponseMessage response = await httpClient.GetAsync(urlParameters);
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<T>(content);
                        return result;
                    }

                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default(T);
            }

        }

        public static async Task<T> RunAsync<T>(string url, string urlParameters)
        {
            return await GetAsync<T>(url, urlParameters);
        }

        



        // unused methods
        /*public string GetUrlParameter(double lat, double longtitude)
        {
            string url;
            url = $"geocode?lat={lat}&lon={longitude}&apikey={apiKey}";
            url = "https://developers.zomato.com/api/v2.1/geocode?lat=" + lat.ToString() + "&lon=" + longitude.ToString() + "&apikey=" + apiKey;
            Debug.WriteLine(url);
            return url;
        }*/
    }
}
