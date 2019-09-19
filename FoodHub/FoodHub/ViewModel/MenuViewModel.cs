using FoodHub.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace FoodHub.ViewModel
{
    class MenuViewModel
    {
        public string ResImage { get; set; }
        public string ResName { get; set; }
        public string ResRating { get; set; }
        public string ResAverageCost { get; set; }        

        public MenuViewModel(string resImage, string resName, string resRating, string resAverageCost)
        {
            this.ResImage = resImage;
            this.ResName = resName;
            this.ResRating = resRating;
            this.ResAverageCost = resAverageCost;
        }        
    }
}
