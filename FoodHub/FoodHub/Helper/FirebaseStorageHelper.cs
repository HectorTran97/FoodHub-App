using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;
using System.IO;
using System.Diagnostics;

namespace FoodHub.Helper
{
    public class FirebaseStorageHelper
    {
        // Connect to firebase storage
        public FirebaseStorage firebaseStorage = new FirebaseStorage("foodhub-39462.appspot.com");

        public async Task<string> UploadImage(Stream fileStream, string fileName)
        {
            try
            {                
                var imageUrl = await firebaseStorage
                    .Child("foodhub")
                    .Child(fileName)
                    .PutAsync(fileStream);
                return imageUrl;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"error:{e}");
                return null;
            }
        }
    }
}
