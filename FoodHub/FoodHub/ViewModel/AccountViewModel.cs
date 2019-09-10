using FoodHub.Helper;
using FoodHub.View;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace FoodHub.ViewModel
{
    class AccountViewModel
    {
        public string Username { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public AccountViewModel(string _username, string _address, string _phoneNumber)
        {
            this.Username = _username;
            this.Address = _address;
            this.PhoneNumber = _phoneNumber;
        }

        public Command EditAccount
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushAsync(new EditAccountPage(this.Username)); });
            }
        }

        //Delete Account
        public Command DeleteCommand
        {
            get { return new Command(Delete); }
        }

        private async void Delete()
        {
            try
            {
                var isdelete = await FireBaseHelper.DeleteUser(this.Username);
                if (isdelete)
                {
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Record not delete", "Ok");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
            }
        }

        //Logout
        public Command LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PopAsync();
                });
            }
        }
    }
}
