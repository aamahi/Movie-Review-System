using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movietest1.OtherClasses
{
    public static class SetNamePosition
    {
        public static string Set(string value)
        {
            string uppercase=value.ToUpper();
            if (uppercase[0] == 'A' || uppercase[0] == 'B'
                || uppercase[0] == 'C' || uppercase[0] == 'D' || uppercase[0] == 'E')
            {
                return "AE";
            }
            if (uppercase[0] == 'F' || uppercase[0] == 'G'
                || uppercase[0] == 'H' || uppercase[0] == 'I' || uppercase[0] == 'J')
            {
                return "FJ";
            }
            if (uppercase[0] == 'K' || uppercase[0] == 'L'
                || uppercase[0] == 'M' || uppercase[0] == 'N' || uppercase[0] == 'O')
            {
                return "KO";
            }
            if (uppercase[0] == 'P' || uppercase[0] == 'Q'
                || uppercase[0] == 'R' || uppercase[0] == 'S' || uppercase[0] == 'T')
            {
                return "PT";
            }
            if (uppercase[0] == 'U' || uppercase[0] == 'V'
                || uppercase[0] == 'W' || uppercase[0] == 'X' || uppercase[0] == 'Y' || uppercase[0] == 'Z')
            {
                return "UZ";
            }
            return "NIL";
        }
    }
}