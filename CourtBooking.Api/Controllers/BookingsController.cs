using Azure;
using CourtBooking.Application.Contracts.IBusiness;
using CourtBooking.Application.Core;
using CourtBooking.Application.ViewModel;
using CourtBooking.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourtBooking.Api.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingBusniess _bookingBusniess;
        protected APIResponse _response;
        public BookingsController(IBookingBusniess bookingBusniess)
        {
            _bookingBusniess = bookingBusniess;
            _response = new();
        }
       

        [HttpPost("MakeBooking")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult >MakeBooking([FromBody] BookingDTO bookingDTO, int userId)
        {
           if(bookingDTO == null)
            {
                return BadRequest(bookingDTO);
            }
            await _bookingBusniess.MakeBooking(bookingDTO, userId);
            return StatusCode(201);

        }

        [HttpGet("{userId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult >GetBookingsForUser(int userId)
        {
            try
            {
                if(userId == 0)
                {
                    return BadRequest(_response);
                }
                var bookingdetails = await _bookingBusniess.GetUserBookings(userId);
                if(bookingdetails.Any() )
                {
                    return Ok(bookingdetails); 
                }
                return NotFound(_response);

            }
            catch (Exception ex)
            {

                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return NoContent();
          

        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task< IActionResult >UpdateBooking(int id, [FromBody] UpdateBookingDTO bookingDTO)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest(_response);
                }
                var existing = await _bookingBusniess.GetBookingDetails(id);
                if(existing == null)
                {
                    return NotFound(_response);
                }
                await _bookingBusniess.UpdateBooking(bookingDTO, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return NoContent(); 

        }

        [HttpDelete("{id}/CancelBooking")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< IActionResult >CancelBooking(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest(_response);
                }
                var existing = await _bookingBusniess.GetBookingDetails(id);
                if (existing == null)
                {
                    return NotFound(_response);
                }
                await _bookingBusniess.CancelBooking(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return Ok(_response);

        }

    }
}
