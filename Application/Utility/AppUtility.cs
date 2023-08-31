using Microsoft.AspNetCore.Mvc;
using OTP.Model.ResponseFormat;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace OTP.ApplicationLayer.Utility
{
    internal class AppUtility
    {
        // Regular expression to check if string is a Indian mobile number
        private const string regexExpForMobile = @"^[6789]\d{9}$";
        public static bool CheckMobileNumber(string MobileNumber)
        {
            try
            {
                return Regex.IsMatch(MobileNumber, regexExpForMobile);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
