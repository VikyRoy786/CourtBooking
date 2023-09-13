using CourtBooking.Application.Contracts.IBusiness;
using CourtBooking.Application.ViewModel;
using CourtBooking.Infstructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CourtBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TennisCourtController : ControllerBase
    {
        private readonly ITennisCourtBusiness _tennisCourtBusiness;
        public TennisCourtController(ITennisCourtBusiness tennisCourtBusiness)
        {
                _tennisCourtBusiness = tennisCourtBusiness;
        }


        [HttpGet]
        public async Task< IActionResult >GetTennisCourtList()
        {
            var tennisCourts = await _tennisCourtBusiness.CourtList();
            return Ok(tennisCourts);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task< IActionResult> CreateTennisCourt([FromBody] TennisCourtCreatedDTO tennisCourtDTO)
        {
            await _tennisCourtBusiness.AddTennisCourt(tennisCourtDTO);
            return Ok(StatusCodes.Status201Created);
        }
        /*

                [HttpPut("{id}")]
                public IActionResult UpdateTennisCourt(int id, [FromBody] TennisCourtDTO tennisCourtDTO)
                {
                    _tennisCourtService.UpdateTennisCourt(id, tennisCourtDTO);
                    return NoContent();
                }

                [HttpDelete("{id}")]
                public IActionResult DeleteTennisCourt(int id)
                {
                    _tennisCourtService.DeleteTennisCourt(id);
                    return NoContent();
                }*/
    }
}
