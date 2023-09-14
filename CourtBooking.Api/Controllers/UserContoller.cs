using CourtBooking.Application.Contracts.IBusiness;
using CourtBooking.Application.ViewModel;
using CourtBooking.Domains.Models;
using CourtBooking.Infstructure;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CourtBooking.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UserContoller(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO request)
        {
           var register =  await _userBusiness.Register(request);

            return Ok(register); 
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            return Ok(request);
        }
    
}
}
