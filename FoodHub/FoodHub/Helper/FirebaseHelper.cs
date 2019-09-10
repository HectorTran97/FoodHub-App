using Firebase.Database;
using Firebase.Storage;
using Firebase.Database.Query;
using FoodHub.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.Helper
{
    class FireBaseHelper
    {
        // Connect app to Firebase by using the API Url 
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
                    Username = item.Object.Username,
                    Password = item.Object.Password,
                    Address = item.Object.Address,
                    PhoneNumber = item.Object.PhoneNumber,
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
                var result = allUser.Where(a => a.Username == username).FirstOrDefault();
                return allUser.Where(a => a.Username == username).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<bool> AddUser(string username, string password, string address, string phoneNumber)
        {
            try
            {
                await firebaseClient
                .Child("User")
                .PostAsync(new User() { Username = username, Password = password, Address = address, PhoneNumber = phoneNumber });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public static async Task<bool> UpdateUser(string username, string password, string address, string phoneNumber)
        {
            try
            {
                var updateUser = (await firebaseClient
                .Child("User")
                .OnceAsync<User>()).Where(a => a.Object.Username == username).FirstOrDefault();
                await firebaseClient
                .Child("User")
                .Child(updateUser.Key)
                .PutAsync(new User() { Username = username, Password = password, Address = address, PhoneNumber = phoneNumber });
                return true;
            }
            catch (Exception e)
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
                .OnceAsync<User>()).Where(a => a.Object.Username == username).FirstOrDefault();
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
