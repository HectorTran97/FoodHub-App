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
    public partial class WelcomePage : ContentPage
    {
        WelcomeViewModel welcomeViewModel;
        public WelcomePage(string username)
        {
            InitializeComponent();
            welcomeViewModel = new WelcomeViewModel(username);
            BindingContext = welcomeViewModel;
        }
    }
}