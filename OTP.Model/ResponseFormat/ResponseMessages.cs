using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTP.Model.ResponseFormat
{
    public sealed class ResponseMessages
    {
        public static readonly string CommonaTryAgainMsg = "Some error occured please try again.";
        public static readonly string OTPGenerationSuccess = "OTP sent to mobile number successfully.";
        public static readonly string OTPGenerationFailedWithException = "OTP generation failed with some technical issue, please try again later";
        public static readonly string ApplicationNameRequired = "Application name is required";
        public static readonly string MobileNumberInvalid = "Please pass appropriate mobile number";
    }
}
