using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Business.Hashing
{
    public class BCryptHashing
    {

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword( password, Salt.Getsalt());
        }       

        public static bool ValidatePassword(string password, string correctHash)
        {
           
           
            for (int i = 0; i <Salt.listSalt.Count ; i++)
            {
                var hashPass =  BCrypt.Net.BCrypt.HashPassword(password, Salt.listSalt[i]);
                if (hashPass == correctHash)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

