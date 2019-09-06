using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FoodHub.View;
using Xamarin.Forms;

namespace FoodHub.ViewModel
{
    public class SignupViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return this.confirmPassword; }
            set
            {
                this.confirmPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }

        public Command SignUpCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Password == ConfirmPassword)
                    {
                        SignUp();
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
                    }
                });
            }
        }

        private async void SignUp()
        {
            //null or empty validation, check if Email and Password is null or empty
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Empty Value", "Please enter Username and Password", "OK");
            }
            else
            {
                var userSignup = await FireBaseHelper.AddUser(Username, Password);
                if (userSignup)
                {
                    await App.Current.MainPage.DisplayAlert("SignUp Successed", "", "OK");
                    await App.Current.MainPage.Navigation.PushAsync(new WelcomePage(Username));                                       
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "SignUp Failed", "OK");
                }
            }
        }
    }
}
