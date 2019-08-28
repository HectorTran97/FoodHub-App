using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FoodHub.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
