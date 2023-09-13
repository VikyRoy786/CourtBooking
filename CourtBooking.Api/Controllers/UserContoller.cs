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
        private readonly BookingDbContext _dbContext;
        public UserContoller(BookingDbContext bookingDbContext)
        {
            _dbContext = bookingDbContext;
        }
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateUsers([FromBody] RegisterUser post)
        {
            var users = new UserMaster();
            users.FirstName = post.FirstName;
            users.LastName = post.LastName;
            users.Email = post.Email;
            users.Password = post.Password;
            await _dbContext.AddAsync(users);
            await _dbContext.SaveChangesAsync();
            return Ok();

        }
        /*[HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            // Implement user registration logic
            // Create a user account, hash password, save to the repository, etc.
            // Return a response
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            // Implement user login logic
            // Authenticate user, generate JWT token, return token to the client, etc.
            // Return a response
        }*/
    
}
}
