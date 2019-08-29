using FoodHub.Model;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public void SignInProcedure(object sender, EventArgs e)
        {
            // Get the Username and Password from the LoginPage form
            User user = new User(Entry_Username.Text, Entry_Password.Text);

            // Validate input 
            if (Entry_Username.Equals(null) || Entry_Password.Equals(null))
            {
                DisplayAlert("Login", "Login Failed!!! No Entry", "Try Again");
            }
            else if (user.CheckValidation())
            {
                DisplayAlert("Login", "Login Successfully!!!", "Ok");
            }
            else
            {
                DisplayAlert("Login", "Login Failed!!! Incorrect username or password", "Try Again");
            }
        }
    }
}