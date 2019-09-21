using FoodHub.Data;
using FoodHub.Helper;
using FoodHub.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.ViewModel
{
    class MenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly RestaurantManager myRestaurantManager = new RestaurantManager();
        readonly RestaurantViewModel restaurantViewModel = new RestaurantViewModel();

        private ObservableCollection<Food> myMenuList;
        public ObservableCollection<Food> MyMenuList
        {
            get { return this.myMenuList; }
            set
            {
                this.myMenuList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyMenuList"));
            }
        }

        public string ResImage { get; set; }
        public string ResName { get; set; }
        public string ResRating { get; set; }
        public string ResAverageCost { get; set; }
        public string ResID { get; set; }

        public MenuViewModel(string resID, string resImage, string resName, string resRating, string resAverageCost)
        {            
            this.ResID = resID;
            this.ResImage = resImage;
            this.ResName = resName;
            this.ResRating = resRating;
            this.ResAverageCost = resAverageCost;
            _ = FetchDataAsync(this.ResID);
        }

        private async Task FetchDataAsync(string ID)
        {
            var resIDList = await myRestaurantManager.FetchRestaurantAsync();

            foreach (var item in resIDList)
            {
                if (ID == item.ID.ToString())
                {
                    var foodList = await FireBaseHelper.GetAllFood(ID);
                    MyMenuList = new ObservableCollection<Food>(foodList);
                }
            }
        }
    }
}
