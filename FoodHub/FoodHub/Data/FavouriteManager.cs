using FoodHub.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.Data
{
    class FavouriteManager
    {
        HttpClient client = new HttpClient();
        List<Restaurant> FavRestaurantList = new List<Restaurant>();
        // api url and key info
        const string url = "https://developers.zomato.com/api/v2.1/";
        const string apiKey = "6e085047a299af09192196321ca6b2ce";

        public async Task<List<Restaurant>> FetchFavAsync(List<decimal> IDList)
        {
            foreach(var a in IDList)
            {
                try
                {
                    using (var httpClient = GetHttpClient(url))
                    {
                        string urlParameters = GetFavUrlParameter(a);
                        HttpResponseMessage response = await httpClient.GetAsync(urlParameters);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<Restaurant>(content);
                            FavRestaurantList.Add(JsonConvert.DeserializeObject<Restaurant>(content));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error{ex.Message}");
                }
            }
            return FavRestaurantList;
        }
        public string GetFavUrlParameter(decimal id)
        {
            string url;
            url = $"restaurant?res_id={id}&apikey={apiKey}";
            return url;
        }
        private static HttpClient GetHttpClient(string url)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }



    }
}
