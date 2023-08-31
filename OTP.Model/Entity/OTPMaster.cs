using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTP.Model.Entity
{
    public class OTPMaster
    {
        public long Id { get; set; }
        public string OTP { get; set; }
        public string MobileNo { get; set; }
        public string ApplicationName { get; set; }
        public string ExpireOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedOn { get; set; }
        public long ResendCount { get; set; }
    }
}
