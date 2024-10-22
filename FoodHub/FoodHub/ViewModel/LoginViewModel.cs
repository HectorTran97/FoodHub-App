﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FoodHub.Data;
using FoodHub.Helper;
using FoodHub.Model;
using FoodHub.View;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace FoodHub.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        //added by Phong 11/9
        private string _connectionStatus;
        //event triggered when connectivity changes
        public event PropertyChangedEventHandler PropertyChanged;
        public string ConnectionStatus
        {
            get { return _connectionStatus; }
            set
            {
                _connectionStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConnectionStatus"));
            }
        }

        //added by Phong 11/9
        async void UpdateConnectionStatus()
        {
            //loop through all connectivity options available.
            if (CrossConnectivity.Current != null && CrossConnectivity.Current.IsConnected == true)
            { 
                ConnectionStatus = "";                
            }
            else
            {
                ConnectionStatus = "Not Connected";
                await App.Current.MainPage.DisplayAlert("Error", ConnectionStatus, "Try Again");
            }                
        }

   
        private const string emptyPhoneNo = "(None)";
        //added update connection stattus by Phong 11/9
        public LoginViewModel()
        {
            //load current status
            UpdateConnectionStatus();
            //Using CrossConnectivity class makes it easier to work across different platforms
            CrossConnectivity.Current.ConnectivityChanged += (sender, e) => { this.UpdateConnectionStatus(); };
        }

        private string username;
        public string Username
        {
            get { return this.username; }
            set
            {
                this.username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        private string password;
        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        public Command SignUp
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushAsync(new SignUpPage()); });
            }
        }

        private async void Login()
        {
            if(CrossConnectivity.Current != null && CrossConnectivity.Current.IsConnected == false)
            {
                await App.Current.MainPage.DisplayAlert("Network error", "Please check ur network connection", "OK");
            }
            //null or empty validation, check if Email and Password is null or empty
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Empty Value", "Please enter Email and Password", "OK");
            }
            else
            {
                var userLogin = await FireBaseHelper.GetUser(Username);
                if (userLogin != null)
                {
                    if (Username == this.Username && Password == this.Password)
                    {
                        
                        var tabbedPage = new TabbedPage();
                        tabbedPage.Children.Add(new RestaurantPage());
                        //tabbedPage.Children.Add(new UserMapPage());

                        if (string.IsNullOrEmpty(userLogin.PhoneNumber))
                        {
                            tabbedPage.Children.Add(new AccountPage(Username, userLogin.Address, emptyPhoneNo));
                        }
                        else
                        {
                            tabbedPage.Children.Add(new AccountPage(Username, userLogin.Address, userLogin.PhoneNumber));
                        }

                        tabbedPage.UnselectedTabColor = Color.FromHex("#D18402");
                        tabbedPage.SelectedTabColor = Color.FromHex("#C03251");
                        tabbedPage.BarBackgroundColor = Color.FromHex("#FFFFFF");

                        await App.Current.MainPage.Navigation.PushAsync(tabbedPage);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
                }
            }
        }
    }
}
