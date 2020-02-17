using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voyatur.extensions
{
    public static class ExtensionMethod
    {
        public static string ControlledSubs(this string value, int length, string defVal)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defVal;
            }
            string result = value;
            if (length < value.Length)
                result = result.Substring(0, length);
            return result;
        }
    }
}