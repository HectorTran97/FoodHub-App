# FoodHub-App

## App Platform: Android + iOS

## Link to gitHub: [GitHub Page] (https://github.com/HectorTran97/FoodHub-App.git)

## *Project Overview*

Similarly, this app will provide the user a list of the restaurants (nearby, favorite,...) to browse and order food. Eat what you like, order what you like, where you like, when you like, just with one tap. The app also provides the delivery address between the restaurants and user's location on the real map for tracking. All the prices, including tax, food, booking fee will all display when you already place your order.

- Student 1: Huy Khanh Le Tran (SID: 216410423)
- Student 2: Phiar Ceu Hnin (SID: 217281975)
- Student 3: Phong Ha Le (SID: 216324041)

## *FirebaseHelper*
* Function GetAllUSer() : *get all the users from the google firebase*

* Parameters: no parameters*

* Return: list of users

```js
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
```
    
* Function GetUSer() : *get a specific user from the google firebase*

* Parameters: no parameters*

* Return: a particular user

```js
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
    
```  
     
* Function GetUSer() : *get all the food from the google firebase*

* Parameters: no parameters*

* Return: a food list

 ```js
 
        public static async Task<List<Food>> GetAllFood()
        {
            try
            {
                var foodList = (await firebaseClient
                    .Child("Food")
                    .OnceAsync<Food>()).Select(item =>
                    new Food
                    {
                        MenuId = item.Object.MenuId,
                        FoodName = item.Object.FoodName,
                        FoodImage = item.Object.FoodImage,
                        FoodDescription = item.Object.FoodDescription,
                        FoodPrice = item.Object.FoodPrice
                    }).ToList();
                return foodList;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
    
  ```  
    
## *FirebaseStorageHelper*

* Function UploadImage() : *upload images to google firebase storage*

* Parameters: stream: fileStream
              string: fileName  

* Return: imageUrl

 ```js
 

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
    
  ```
    
 ## *RestaurantManager*
* Function GetUrlParameter() : *get url of the restaurant*

* Parameters: double: longtitude
              double: latitude  

* Return: url of a restaurant

 ```js
        public string GetUrlParameter(double latitude, double longitude)
        {
            string url;
            url = $"geocode?lat={latitude}&lon={longitude}&apikey={apiKey}";
            return url;
        }
    
```
* Function GetUrlParameter() : *get all the restaurants nearby using zomato api*

* Parameters: *no parameters*

* Return: list of restaurants

 ```js
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
                        return restaurantList = ConvertToRes(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error{ex.Message}");
            }
            return restaurantList;
        }
    
  ```
