using Firebase.Database;
using Firebase.Database.Query;
using FoodHub.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.ViewModel
{
    class FireBaseHelper
    {
        // Connect app to Firebases by using the API Url 
        public static FirebaseClient firebaseClient = new FirebaseClient("https://foodhub-39462.firebaseio.com/");

        public static async Task<List<User>> GetAllUser()
        {
            try
            {
                var userlist = (await firebaseClient
                .Child("User")
                .OnceAsync<User>()).Select(item =>
                new User
                {
                    _Username = item.Object._Username,
                    _Password = item.Object._Password
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<User> GetUser(string username)
        {
            try
            {
                var allUser = await GetAllUser();
                await firebaseClient
                .Child("User")
                .OnceAsync<User>();
                return allUser.Where(a => a._Username == username).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<bool> AddUser(string username, string password)
        {
            try
            {
                await firebaseClient
                .Child("User")
                .PostAsync(new User() { _Username = username, _Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public static async Task<bool> UpdateUser(string username, string password)
        {
            try
            {
                var updateUser = (await firebaseClient
                .Child("User")
                .OnceAsync<User>()).Where(a => a.Object._Username == username).FirstOrDefault();
                await firebaseClient
                .Child("User")
                .Child(updateUser.Key)
                .PutAsync(new User() { _Username = username, _Password = password });
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public static async Task<bool> DeleteUser(string username)
        {
            try
            {
                var deletePerson = (await firebaseClient
                .Child("User")
                .OnceAsync<User>()).Where(a => a.Object._Username == username).FirstOrDefault();
                await firebaseClient.Child("User").Child(deletePerson.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
    }
}
