using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FoodHub.Model;
using FoodHub.View;
using Xamarin.Forms;

namespace FoodHub.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {

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
            //null or empty validation, check if Email and Password is null or empty
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Empty Value", "Please enter Email and Password", "OK");
            }
            else
            {
                var userLogin = await FireBaseHelper.GetUser(Username);
                if (!userLogin.Equals(null))
                {
                    if (Username == userLogin._Username && Password == userLogin._Password)
                    {
                        await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                        //Navigate to Wellcom page after successfuly login
                        //pass username to welcom page
                        await App.Current.MainPage.Navigation.PushAsync(new WelcomePage(Username));
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
                }                    
            }
        }
    }
}
