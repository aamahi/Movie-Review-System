using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movietest1.OtherClasses
{
    public static class IdGenerator
    {
        
            public static string Generate(int digits)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[digits];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);//this is random key

                return finalString;
            }
        
        
    }
}