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
        public int ResID { get; set; }

        public MenuViewModel(int resID, string resImage, string resName, string resRating, string resAverageCost)
        {
            this.ResID = resID;
            this.ResImage = resImage;
            this.ResName = resName;
            this.ResRating = resRating;
            this.ResAverageCost = resAverageCost;
            _ = FetchDataAsync();
        }

        public async Task FetchDataAsync()
        {
            var list = await FireBaseHelper.GetAllFood();
            MyMenuList = new ObservableCollection<Food>(list);
        }
    }
}
