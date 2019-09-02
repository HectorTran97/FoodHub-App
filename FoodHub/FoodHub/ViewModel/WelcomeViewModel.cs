using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace FoodHub.ViewModel
{
    class WelcomeViewModel
    {
        public string Password { get; private set; }
        public string Username { get; private set; }

        public WelcomeViewModel(string username)
        {
            this.Username = username;
        }

        public Command UpdateCommand
        {
            get { return new Command(Update); }
        }        

        private async void Update()
        {
            try
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    var isUpdate = await FireBaseHelper.UpdateUser(Username, Password);
                    if (isUpdate)
                    {
                        await App.Current.MainPage.DisplayAlert("Update Successed", "", "OK");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Record not update", "OK");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Password Require", "Please enter your Password", "OK");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
            }
        }

        public Command DeleteCommand
        {
            get { return new Command(Delete); }
        } 

        private async void Delete()
        {
            try
            {                
                var isDelete = await FireBaseHelper.DeleteUser(Username);
                if (isDelete)
                {
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Record not delete", "OK");
                }                
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
            }
        }

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
