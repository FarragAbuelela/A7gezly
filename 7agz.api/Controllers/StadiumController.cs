using _7agz.Core;
using _7agz.Core.DTOs;
using _7agz.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace _7agz.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StadiumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("AddStadium")]
        public IActionResult AddStadium([FromBody] StadiumDTO stadium)
        {
            return Ok(_unitOfWork.Stadiums.Add(new Stadium
            {
                StadiumOwnerId = stadium.StadiumOwnerId,
                Capacity = stadium.Capacity,
                HourPrice = stadium.HourPrice,
                Longitude = stadium.Longitude,
                Latitude = stadium.Latitude,
                Vestiary = stadium.Vestiary,
                Cafeteria = stadium.Cafeteria,
                ParkingArea = stadium.ParkingArea,
                Name = stadium.Name,
                Start = stadium.Start,
                End = stadium.End
            }));
        }

        /*[HttpGet("GetOwnerStadiums")]
        public IActionResult GetOwnerStadiums(int id)
        {
            return Ok(_unitOfWork.Stadiums.FindAll(s => s.StadiumOwnerId == id));
        }
*/

        [HttpGet("GetSatdiums")]
        public IActionResult GetStadiums(int id)
        {
            return Ok(_unitOfWork.Stadiums.GetById(id));
        }



        [HttpPatch("{id}")]
        public IActionResult EditStadium(int id, [FromBody] JsonPatchDocument stadium)
        {
            var _stadium = _unitOfWork.Stadiums.GetById(id);
            if (_stadium is null)
            {
                return NotFound();
            }
            return Ok(_unitOfWork.Stadiums.Update(id, stadium));

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var stadium = _unitOfWork.Stadiums.GetById(id);
            if (stadium is null) return NotFound();
            _unitOfWork.Stadiums.Delete(stadium);
            return StatusCode(NoContent().StatusCode);
        }

        [HttpPut("id")]
        public IActionResult UpdateByPut(int id, [FromBody] StadiumDTO stadium)
        {
            var _stadium = _unitOfWork.Stadiums.GetById(id);
            if (_stadium is null) return NotFound();
            _stadium.StadiumOwnerId = stadium.StadiumOwnerId;
            _stadium.Capacity = stadium.Capacity;
            _stadium.HourPrice = stadium.HourPrice;
            _stadium.Longitude = stadium.Longitude;
            _stadium.Latitude = stadium.Latitude;
            _stadium.Vestiary = stadium.Vestiary;
            _stadium.Cafeteria = stadium.Cafeteria;
            _stadium.ParkingArea = stadium.ParkingArea;
            _stadium.Name = stadium.Name;
            _stadium.Start = stadium.Start;
            _stadium.End = stadium.End;
            return Ok(_unitOfWork.Stadiums.UpdateByPut(id, _stadium));
        }


        [HttpGet("GetReservedHours")]
        public IActionResult GetHours(int id)
        {
            var list = _unitOfWork.ReservedHours.FindAll(x => x.StadiumId == id).ToList();
            return Ok(list);
        }

    }
}
