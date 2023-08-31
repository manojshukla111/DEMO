using OTP.BussinessLayer.Services.Interface;
using OTP.DataAccessLayer.Interface;
using OTP.Model.Entity;
using OTP.Model.ResponseFormat;
using OTP.Model.ResponseModel;
using OTP.Model.RRModel;
namespace OTP.BussinessLayer.Services.Implementation
{
    public class OTPService : IOTPService
    {
        private readonly IUnitOfWork _repository;
        public OTPService(IUnitOfWork repository)
        {
            _repository = repository;
        }
        public async Task<OTPMaster> GenerateOTP(GenerateOTPRequestModel requestModel)
        {

            OTPMaster OptResponse = new();
            //generate random otp for current request
            Random generator = new Random();
            string random_otp = generator.Next(0, 1000000).ToString("D6");

            //converted current request to Otp entity
            var OTPMasterObj = new OTPMaster()
            {
                OTP = random_otp,
                MobileNo = requestModel.mobileNumber,
                CreatedOn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                CreatedBy = Guid.NewGuid().ToString(),
                ResendCount = 0,
                ApplicationName = requestModel.applicationName,
                ExpireOn = DateTime.Now.AddMinutes((double)(requestModel.expInMin is not null && requestModel.expInMin != 0 ? requestModel.expInMin : 10)).ToString("dd/MM/yyyy HH:mm:ss"),
            };
            OptResponse = await _repository.OTPRepository.AddAsync(OTPMasterObj);
            _ = _repository.save();
            return OptResponse;
        }

        public async Task<OTPMaster> ResendOTP(GenerateOTPRequestModel requestModel)
        {
            throw new NotImplementedException();
            //finding otp in databse 
            /* var find_otp = _repository.OTPRepository.FirstOrDefault(x => x.ApplicationName == requestModel.applicationName && x.mobileNumber == requestModel.mobileNumber);
             // if time limit expired, genrating new otp and saving in DB
             if ( DateTime.Parse(find_otp.ExpireOn) < DateTime.Now)
             {
                 //generate random otp for current request
                 OTPMaster OptResponse = new();
                 //generate random otp for current request
                 Random generator = new Random();
                 string random_otp = generator.Next(0, 1000000).ToString("D6");

                 //converted current request to Otp entity
                 var OTPMasterObj = new OTPMaster()
                 {
                     OTP = random_otp,
                     MobileNo = requestModel.mobileNumber,
                     CreatedOn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                     CreatedBy = Guid.NewGuid().ToString(),
                     ResendCount = 0,
                     ApplicationName = requestModel.applicationName,
                     ExpireOn = DateTime.Now.AddMinutes((double)(requestModel.expInMin is not null && requestModel.expInMin != 0 ? requestModel.expInMin : 10)).ToString("dd/MM/yyyy HH:mm:ss"),
                 };

                 OptResponse = await _repository.OTPRepository.AddAsync(OTPMasterObj);

                 return OptResponse;
             }
             else
             {
                 //found OTP in database and its not expired so stroing otp in DB and chaning the exp_time,count,updateon and resend 
                 find_otp.ExpireOn = DateTime.Now.AddMinutes((double)(requestModel.expInMin is not null && requestModel.expInMin != 0 ? requestModel.expInMin : 10)).ToString("dd/MM/yyyy HH:mm:ss");
                 find_otp.ResendCount = find_otp.ResendCount + 1;
                 find_otp.UpdatedOn = DateTime.Now.ToString();

                 return Ok("OTP Resend SSuccessfully");
             }
 */

        }

        Task<ValidateOTPResponseModel> IOTPService.ValidateOTP(ValidateOTPRequestModel requestModel)
        {
            throw new NotImplementedException();
           /*  var validateOTPInDB = _repository.OTPRepository
                        .Any(x =>
                        x.MobileNo == requestModel.MobileNo
                        && x.ApplicationName == requestModel.ApplicationName
                        && x.OTP == requestModel.OTP
                        && DateTime.Parse(x.ExpireOn) > DateTime.Now);

             if (validateOTPInDB)
             {
                 var otp_remove = _repository.OTPRepository.FirstOrDefault(x => x.ApplicationName == requestModel.ApplicationName && x.MobileNo == requestModel.MobileNo);
                 if (otp_remove != null)
                     _repository.OTPRepository.remove(otp_remove);

                 return validateOTPInDB;
             }

             else
                 return validateOTPInDB;*/
        }
    }
}
