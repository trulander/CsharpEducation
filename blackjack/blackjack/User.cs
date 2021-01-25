using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    public class User
    {
        public int UserScore { get; set; }
        public string UserName { get; set; }
        public string Type { get; protected set; }
        public bool Missed { get; set; }
        public User(string userName,string type)
        {
            UserName = userName;
            Type = type;
        }
        public User()
        {

        }

    }
}
