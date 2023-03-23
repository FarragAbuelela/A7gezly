using GraduationProjectDemo.DTOs;
using GraduationProjectDemo.Models;
using GraduationProjectDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPlayerServices _playerServices;

        public PersonController(IPlayerServices playerServices)
        {
            _playerServices = playerServices;
        }



        // GET: api/<PersonController>
        [HttpGet]
        public ActionResult Get() => Ok(_playerServices.GetAllPlayers());


        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id) => Ok(_playerServices.GetPlayer(id));

        // POST api/<PersonController>
        [HttpPost]
        public ActionResult Post([FromBody] CreatePlayerDTO player)
        {
            
           
            Person person = new()
            {
                Name = player.Name,
                PhoneNumber = player.PhoneNumber,
                Email = player.Email,
                Age = player.Age,
                Country = player.Country,
                City = player.City,
                Gender = player.Gender,
                Password = player.Password,
                Position = player.Position,
                street = player.street
            };
            var Player = _playerServices.CreatePlayer(person);
            return Ok(Player);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreatePlayerDTO Player)
        {
            
            if (id != Player.Id)
            {
                return BadRequest("The PK is Wrong !!!");
            }
            var player = _playerServices.GetPlayer(id);
            if(player is null)
            {
                return NotFound();
            }
            player = _playerServices.UpdatePlayer(player);
            return StatusCode(NoContent().StatusCode);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Player = _playerServices.GetPlayer(id);
            if (Player is null)
            {
                return NotFound();
            }
            var player = _playerServices.DeletePlayer(Player);
            return Ok(Player);
        }

    }
}
