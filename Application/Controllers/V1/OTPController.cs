using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using IL.Common.Extensions.Cache;
using OTP.Model.ResponseModel;
using OTP.Model.ResponseFormat;
using OTP.Model.RRModel;
using OTP.BussinessLayer.Services.Interface;
using OTP.ApplicationLayer.Utility;
using System.Net;
using System.Diagnostics;
using OTP.DataAccessLayer.Interface;

namespace OTP.ApplicationLayer.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {

        private readonly IOTPService _service;
        private readonly IUnitOfWork unitOfWork;
        public OTPController(IOTPService service, IUnitOfWork unit)
        {
            _service = service;
            unitOfWork = unit;
        }

        [HttpPost]
        [Route("Generate")]
        public async Task<IActionResult> GenerateOTP([FromBody] GenerateOTPRequestModel requestModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(requestModel.applicationName))
                {
                    return BadRequest(new Result<OTPResponseModel>(HttpStatusCode.BadRequest, ResponseMessages.ApplicationNameRequired, null));
                }
                else if (string.IsNullOrWhiteSpace(requestModel.mobileNumber) || !AppUtility.CheckMobileNumber(requestModel.mobileNumber))
                {
                    return BadRequest(new Result<OTPResponseModel>(HttpStatusCode.BadRequest, ResponseMessages.MobileNumberInvalid, null));
                }
                else
                {
                    var responseData = await _service.GenerateOTP(requestModel);
                    if (responseData is not null && responseData.Id > 0)
                    {
                        return Ok(new Result<OTPResponseModel>(HttpStatusCode.OK, ResponseMessages.OTPGenerationSuccess, null));
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, new Result<OTPResponseModel>(HttpStatusCode.InternalServerError, ResponseMessages.CommonaTryAgainMsg, null));
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Result<OTPResponseModel>(HttpStatusCode.InternalServerError, ResponseMessages.OTPGenerationFailedWithException, null));
            }

        }

        [HttpPost]
        [Route("Validate")]
        public async Task<IActionResult> ValidateOTP([FromBody] ValidateOTPRequestModel requestModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(requestModel.OTP))
                {
                    return BadRequest(new Result<OTPResponseModel>(HttpStatusCode.BadRequest, ResponseMessages.ApplicationNameRequired, null));
                }
                
                else
                {
                    var responseData = await _service.ValidateOTP(requestModel);
                    if (responseData is not null )
                    {
                        return Ok(new Result<OTPResponseModel>(HttpStatusCode.OK, ResponseMessages.OTPGenerationSuccess, null));
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, new Result<OTPResponseModel>(HttpStatusCode.InternalServerError, ResponseMessages.CommonaTryAgainMsg, null));
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Result<OTPResponseModel>(HttpStatusCode.InternalServerError, ResponseMessages.OTPGenerationFailedWithException, null));
            }
            return Ok(await _service.ValidateOTP(requestModel));

        }

        [HttpPost]
        [Route("Resend")]
        public async Task<IActionResult> ResendOTP([FromBody] GenerateOTPRequestModel requestModel)
        {
            return Ok(await _service.ResendOTP(requestModel));
        }

    }
}

