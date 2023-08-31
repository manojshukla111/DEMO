using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTP.Model.RRModel
{
    public class ValidateOTPRequestModel
    {
        public string MobileNo { get; set; }
        public string OTP { get; set; }

        public string ApplicationName { get; set; }
    }
}
