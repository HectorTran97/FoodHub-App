using FoodHub.Helper;
using FoodHub.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace FoodHub.ViewModel
{
    class EditAccountViewModel : INotifyPropertyChanged
    {
        private const string nullPhoneNumber = "(None)";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Username { get; set; }

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

        public EditAccountViewModel(string username)
        {
            this.Username = username;
        }

        public Command UpdateCommand
        {
            get { return new Command(Update); }
        }

        //Update user data
        private async void Update()
        {
            try
            {
                if (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Address))
                {
                    var isupdate = await FireBaseHelper.UpdateUser(this.Username, this.Password, this.Address, this.PhoneNumber);
                    if (isupdate)
                    {
                        await App.Current.MainPage.DisplayAlert("Update Success", "", "Ok");
                        var userInfo = await FireBaseHelper.GetUser(this.Username);
                        if (string.IsNullOrEmpty(userInfo.PhoneNumber))
                        {
                            await App.Current.MainPage.Navigation.PushAsync(new AccountPage(this.Username, this.Address, nullPhoneNumber));
                        }
                        else
                        {
                            await App.Current.MainPage.Navigation.PushAsync(new AccountPage(this.Username, this.Address, this.PhoneNumber));
                        }                        
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Record not update", "Ok");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Password and Address Require", "Please Enter your password or address", "Ok");
                }
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error:{e}");
            }
        }
    }
}
