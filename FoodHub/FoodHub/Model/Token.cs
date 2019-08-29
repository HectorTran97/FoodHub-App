using System;
using System.Collections.Generic;
using System.Text;

namespace FoodHub.Model
{
    public class Token
    {
        public int Id { get; set; }
        public string Access_token { get; set; }
        public string Error_detection { get; set; }
        public DateTime expire_time { get; set; }

        public Token()
        {

        }
    }
}
