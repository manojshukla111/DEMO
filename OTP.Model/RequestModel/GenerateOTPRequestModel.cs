using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTP.Model.RRModel
{
    public class GenerateOTPRequestModel
    {
        public string mobileNumber { get; set; }

        public string applicationName { get; set; }
        public int? expInMin { get; set; }
    }
}
