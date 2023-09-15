using CourtBooking.Application.Contracts.IBusiness;
using CourtBooking.Application.Core;
using CourtBooking.Application.ViewModel;
using CourtBooking.Infstructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CourtBooking.Api.Controllers
{
    [Route("api/tennis")]
    [ApiController]
    public class TennisCourtController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ITennisCourtBusiness _tennisCourtBusiness;
        public TennisCourtController(ITennisCourtBusiness tennisCourtBusiness)
        {
                _tennisCourtBusiness = tennisCourtBusiness;
            _response = new();
        }


        [HttpGet]
        [Route("list")]
        [Authorize]
        [ProducesResponseType(typeof(PaginatedItems<TennisCourtGridView>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task <IActionResult> GetTennisCourtList([FromQuery] string sort, [FromQuery] string sortColumn, [FromQuery] int perPage = 10, [FromQuery] int page = 0)
        {
            var request = new GetListRequest()
            {
                Sort = sort,
                SortColumn = sortColumn,
                PerPage = perPage,
                Page = page
            };
            var tennisCourts = await _tennisCourtBusiness.CourtList(request);
            return Ok(tennisCourts);
        }


        [HttpGet("{id}/getcourtDetails")]
        [Authorize(Roles ="admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCourtDetails(int id)
        {
            try
            {
                if (id == 0)
                {

                    return BadRequest(_response);
                }
                var existing = await _tennisCourtBusiness.GetTennisCourtbyId(id);
                if (existing == null)
                {
                    return NotFound(_response);
                }
               
                return Ok(existing);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return Ok(_response);


        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task< IActionResult> CreateTennisCourt([FromBody] TennisCourtCreatedDTO tennisCourtDTO)
        {
            if( await _tennisCourtBusiness.GetTennisCourtList(tennisCourtDTO.Name)!=null )
            {
                ModelState.AddModelError("ErrorMessage", "Court AlredayExists");
                return BadRequest(ModelState);
            }
            if(tennisCourtDTO == null)
            {
                return BadRequest(tennisCourtDTO);
            }
            
            await _tennisCourtBusiness.Create(tennisCourtDTO);
            return StatusCode(201);
            

            
        }
        

        [HttpPut("{id}/update")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult>UpdateTennisCourt(int id, [FromBody] TennisCourtUpdateDTO tennisCourtDTO)
        {
            try
            {
                if(id == 0)
                {
                    
                    return BadRequest(_response);
                }
                var existing = await _tennisCourtBusiness.GetTennisCourtbyId(id);
                if (existing == null)
                {
                    return NotFound(_response);
                }
                await _tennisCourtBusiness.Update(tennisCourtDTO, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return NoContent();


        }

        [HttpDelete("{id}/DeleteCourt")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< IActionResult >DeleteTennisCourt(int id)
        {
            try
            {
                if (id == 0)
                {
                    
                    return BadRequest(_response);
                }
                var existing = await _tennisCourtBusiness.GetTennisCourtbyId(id);
                if (existing == null)
                {
                    return NotFound(_response);
                }
                await _tennisCourtBusiness.Delete(id);
              
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
