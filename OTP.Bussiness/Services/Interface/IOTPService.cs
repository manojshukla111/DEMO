using OTP.Model.Entity;
using OTP.Model.ResponseFormat;
using OTP.Model.ResponseModel;
using OTP.Model.RRModel;

namespace OTP.BussinessLayer.Services.Interface
{
    public interface IOTPService
    {
        Task<OTPMaster> GenerateOTP(GenerateOTPRequestModel requestModel);
        Task<OTPMaster> ResendOTP(GenerateOTPRequestModel requestModel);
        Task<ValidateOTPResponseModel> ValidateOTP(ValidateOTPRequestModel requestModel);
    }
}
