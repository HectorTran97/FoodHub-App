using FoodHub.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodHub
{
    // this is the main app
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Set the login page as main page
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            // we will try to track the state of login or logout
            // if loggedin state = present user to tabbed page (main page)
            // if logout state = present user to login page
        }
    }
}
