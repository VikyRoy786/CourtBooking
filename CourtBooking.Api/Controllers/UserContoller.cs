using Azure;
using CourtBooking.Application.Contracts.IBusiness;
using CourtBooking.Application.Core;
using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using CourtBooking.Infstructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

namespace CourtBooking.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        protected APIResponse _response;
        public UserContoller(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
           _response = new();
        }

        

        [HttpPost("register/admin")]
        public async Task<IActionResult> AdminRegister([FromBody] RegistrationRequestDTO request)
        {
            bool ifUserisunique = await _userBusiness.IsuniqueUser(request.UserName);
            if (!ifUserisunique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }
;           var register =  await _userBusiness.AdminRegistration(request);
            if (register == null)
            {
               _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpPost("register/users")]
        public async Task<IActionResult> UserRegister([FromBody] RegistrationRequestDTO request)
        {
            bool ifUserisunique = await _userBusiness.IsuniqueUser(request.UserName);
            if (!ifUserisunique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }
               var register = await _userBusiness.UserRegistration(request);
            if (register == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var loginresponse = await _userBusiness.Login(request);
            if (loginresponse.Users == null || string.IsNullOrEmpty(loginresponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }


            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginresponse;
            return Ok(_response);
        }
    
}
}
