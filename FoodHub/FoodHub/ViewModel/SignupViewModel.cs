using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FoodHub.Helper;
using FoodHub.View;
using Xamarin.Forms;

namespace FoodHub.ViewModel
{
    public class SignupViewModel : INotifyPropertyChanged
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

        private string address;
        public string Address
        {
            get { return this.address; }
            set
            {
                this.address = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Address"));
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set
            {
                this.phoneNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PhoneNumber"));
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

        public Command BackCommand
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushAsync(new LoginPage()); });
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
                var userSignup = await FireBaseHelper.AddUser(Username, Password, Address, PhoneNumber);
                if (userSignup)
                {
                    await App.Current.MainPage.DisplayAlert("SignUp Successed", "", "OK");
                    await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "SignUp Failed", "OK");
                }
            }
        }
    }
}
