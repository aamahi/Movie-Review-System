using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movietest1.OtherClasses
{
    public static class StringExt
    {
        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}