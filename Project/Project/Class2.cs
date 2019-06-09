using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    class Receptionists
    {

        static string UserName;
        static string Passwords;

        public void SetData(string s1, string s2)
        {
            UserName = s1;
            Passwords = s2;
        }

        public string GetUserName()
        {
            return UserName;
        }

        public string GetPasswords()
        {
            return Passwords;
        }


    }
}
