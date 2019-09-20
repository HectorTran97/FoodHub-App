using System;
using System.Collections.Generic;
using System.Text;

namespace FoodHub.Model
{
    public class Food
    {
        // Properties to get Foodname, Foodimage, Fooddescription, Foodprice and Menuid
        public string FoodName { get; set; }
        public string FoodImage { get; set; }
        public string FoodDescription { get; set; }
        public string FoodPrice { get; set; }
        public string MenuId { get; set; }

        public Food()
        {

        }
    }
}
