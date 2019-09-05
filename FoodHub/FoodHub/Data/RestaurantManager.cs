﻿using System;
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

        private double latitude;
        private double longitude;
        /*const string url = "https://developers.zomato.com/api/v2.1/";
        const string apiKey = "749b7981ff9e98b3b0ed487c17028e6e";*/ // this one is from online (better not to use it)

        // this link and api key is for us
        const string url = "https://developers.zomato.com/api/v2.1/";
        const string apiKey = "6e085047a299af09192196321ca6b2ce";


        public async Task<List<Restaurant>> FetchRestaurantAsync()
        {
            try
            {
                using (var httpClient = GetHttpClient(url))
                {
                    string urlParameters = GetUrlParameter(await GetLocationAsync(1), await GetLocationAsync(2));
                    //string urlParameters = GetUrlParameter(-37.847814, 145.114982);
                    //string urlParameters = $"search?entity_id=59&entity_type=city&apikey={apiKey}";
                    HttpResponseMessage response = await httpClient.GetAsync(urlParameters);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<RestaurantList>(content);
                        var resList = ConvertToRes(result);
                        restaurantList = resList;
                        int count = result.Restaurants.Count;
                        /*for (int i = 0; i <= result.Restaurants.Count; i++)
                        {
                            restaurantList.Add(result.Restaurants[i].Restaurant);
                            
                        }*/
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message);
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
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
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
            List<Restaurant> result = null;
            for(int i = 0; i <= data.Restaurants.Count; i++)
            {
                result.Add(data.Restaurants[i].Restaurant);
            }
            return result;
        }




    }
}
