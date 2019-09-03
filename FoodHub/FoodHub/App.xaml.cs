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
            // (Ceu) I'll now comment this as I need to work on the other pages
            // we will put them in if statement later to decide which (login page or tabbed page) page to start with
            // feel free to comment tabbedpage section and run this login page first
            //MainPage = new NavigationPage(new LoginPage());

            var tabbedPage = new TabbedPage();
            tabbedPage.Children.Add(new RestaurantPage());
            tabbedPage.Children.Add(new FavouritePage());
            tabbedPage.Children.Add(new UserMapPage());
            tabbedPage.Children.Add(new AccountPage());
            MainPage = tabbedPage;

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
