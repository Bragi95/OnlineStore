using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Business.Hashing
{
    public static class Salt
    {

        public static List<string> listSalt = new List<string>() 
        {
            "$2a$12$gRhJy0cRc0DDdb6oqEcESO",
            "$2a$12$hch9ITwzPSkjRbCZnVG19u",
            "$2a$12$BDo4tnEeDryx4eju0480m.",
            "$2a$12$qwe4tnEeDryxR%$u0480m."
        };       

        public static string Getsalt()
        {
            Random random = new Random();
            return listSalt[random.Next(0, listSalt.Count-1)];
        }
    }
}
