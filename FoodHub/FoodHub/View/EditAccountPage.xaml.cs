using FoodHub.Helper;
using FoodHub.ViewModel;
using Plugin.Media.Abstractions;
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
    public partial class EditAccountPage : ContentPage
    {
        readonly EditAccountViewModel editAccountViewModel;
        public EditAccountPage(string username)
        {
            editAccountViewModel = new EditAccountViewModel(username);
            InitializeComponent();
            BindingContext = editAccountViewModel;
        }
    }
}