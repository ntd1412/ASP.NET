using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using _20T1080027.DomainModels;

namespace _20T1080027.Web
{
    /// <summary>
    /// chuyển chuoix ngày dạng đ/MM/yyyy sang giá trị ngày(
    /// </summary>
    public class Converter
    {
        public static DateTime? DMYStringToDateTime(string s, string format = "d/M/yyyy")
        {
            try
            {
                return DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }
        }
        public static UserAccount CookieToUserAccount(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserAccount>(value);
        }
    }
   
}