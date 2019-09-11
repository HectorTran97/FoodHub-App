using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodHub.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantDetailsPage : ContentPage
    {
        private ObservableCollection<Menu> menuList;
        public RestaurantDetailsPage(int id, string name)
        {
            InitializeComponent();
            SampleLabelID.Text = "Restaurant ID: " + id.ToString();
            SampleLabelName.Text = "Name: " + name;
        }

        public class Menu
        {

        }
    }
}