using FoodHub.Model;
using FoodHub.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodHub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        readonly MenuViewModel menuViewModel;
        public MenuPage(int resID, string resImage, string resName, string ResRating, string ResAverageCost)
        {
            menuViewModel = new MenuViewModel(resID, resImage, resName, ResRating, ResAverageCost);
            InitializeComponent();
            BindingContext = menuViewModel;
        }
    }
}