using System;
using System.Collections.Generic;
using System.Text;

namespace FoodHub.Model
{
    public class User
    {        
        // Properties to get ID, Username and Password
        public int ID { get; set; }
        public string _Username { get; set; }
        public string _Password { get; set; }

        // Constructor
        public User()
        {

        }

        public User(string Username, string Password)
        {
            this._Username = Username;
            this._Password = Password;
        }
    }
}
