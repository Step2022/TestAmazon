using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
namespace TestAmazon.Utility
{
    public static class RegularExp
    {
        public static bool IsInt(string number)
        {
            Regex reg = new Regex("[0-9]+");
            if(new Regex("^[0-9]+$").Match(number).Success)
            {
                return true;
            }
            return false;
        }
        public static bool IsDouble(string number)
        {
            Regex reg = new Regex("[0-9]+");
            number = number.Replace('.', ',');
            if (new Regex("(^[0-9]+$)|(^[0-9]+[,.][0-9]+$)").Match(number).Success)
            {
                return true;
            }
            return false;
        }
    }
}