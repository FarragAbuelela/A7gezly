using _7agz.Core;
using _7agz.Core.DTOs;
using _7agz.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using _7agz.Core.Service;
using _7agz.Core.Consts;

namespace _7agz.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public PlayerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_unitOfWork.Players.GetById(id));
        [HttpGet("GetAll")]
        public IActionResult GetAll() => Ok(_unitOfWork.Players.GetAll());

        [HttpPost]
        public IActionResult Add([FromBody] PlayerDTO player) {

            var check = _unitOfWork.Players.Find(_player => _player.Email == player.Email);
            if (check is not null)
            {
                return BadRequest("This account is already exist!!!");
            }

            Player _player = new()
            {
                Name = player.Name,
                PhoneNumber = player.PhoneNumber,
                Email = player.Email,
                Birthdate = player.Birthdate,
                Country = player.Country,
                City = player.City,
                Password = player.Password,
                PlayerPosition = player.PlayerPosition,
                street = player.street
            };
            var result = _unitOfWork.Players.Add(_player);
            _unitOfWork.PlayersData.Add(new PlayerData { PlayerId = result.Id, player_possition = (int)result.PlayerPosition });

            Services.SendRegisterationEmail(_player.Email, _player.Name);

            return Ok(result);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO player) {

            var result = _unitOfWork.Players.Find(_player => _player.Email == player.Email && _player.Password == player.Password);
            if(result is null)
            {
                return NotFound("The user name or password does not correct !!!");
            }
            return Ok(result);
        }

        [HttpGet("GetMatchDetails")]
        private IActionResult GetPlayerWithTeam(string email)
        {

            var player = _unitOfWork.Players.MatchDetails(b => b.Email == email);
            return Ok(player);
            #region comment
            /*  
                        var player = _unitOfWork.Players.Find(player => player.Name == name);
                        *//*var playerDetails = player.Teams.Select(x => new { x.Stadium.Name }).FirstOrDefault();
                        string SName = playerDetails.Name;*//*
                        var teams = _unitOfWork.Teams.FindAll(team => team.Players.Contains(player));
                        var team = teams.FirstOrDefault();
                        var teamHourData = from subTeam in _unitOfWork.Teams
                                           join reservedHour in _unitOfWork.ReservedHours on
                                           subTeam.ReservedHourId equals reservedHour.Id into teamHour
                                           select new { subTeam, reservedHour };
                        //this return for test only
                        return Ok(new { player.Name, player.Email, teams.FirstOrDefault().Id});*/
            #endregion

        }
        /*
                [HttpGet("GetPlayerData")]
                public IActionResult GetPlayerData(int id)
                {
                    return Ok(_unitOfWork.PlayersData.Find(b => b.Player.Id == id, new string[] { "Player" }));
                }*/
        [HttpGet("GetPlayerData")]
        public IActionResult GetPlayerData(int id)
        {
            return Ok(_unitOfWork.Players.Find(p => p.Id == id, new string[] { "PlayerData" }));
        }


        [HttpPatch("{id}")]
        public IActionResult EditPlayer(int id,[FromBody]JsonPatchDocument player)
        {
            var _player = _unitOfWork.Players.GetById(id);
            if(_player is null)
            {
                return NotFound();
            }
            _player = _unitOfWork.Players.Update(id, player);
            return Ok(player);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var player = _unitOfWork.Players.GetById(id);
            if (player is null) return NotFound();
            _unitOfWork.Players.Delete(player);
            return StatusCode(NoContent().StatusCode);
        }

        [HttpPut("id")]
        public IActionResult UpdateByPut(int id, [FromBody] PlayerDTO player)
        {
            var _player = _unitOfWork.Players.GetById(id);
            if(_player is null) return NotFound();
            if(_player.Email != player.Email)
            {
                return BadRequest("Changing E-mail does not allowed !!!");
            }
            _player.Name = player.Name;
            _player.Birthdate = player.Birthdate;
            _player.City = player.City;
            _player.Country = player.Country;
            _player.Email = player.Email;
            _player.Password = player.Password;
            _player.PhoneNumber = player.PhoneNumber;
            _player.PlayerPosition = player.PlayerPosition;
            _player.street = player.street;
            return Ok(_unitOfWork.Players.UpdateByPut(id, _player));
        }

        [HttpGet("MatchDetails")]
        public IActionResult getMatchDetails(int id) => Ok(_unitOfWork.Players.MatchDetails(player => player.Id == id));


        [HttpGet("PlayersByPosition")]
        public IActionResult getPlayersByPosition(Position position, DateTime time)
        {
            return Ok(_unitOfWork.Players.GetPlayersByPosition(position, time));
        }


        [HttpPost("AddRatePlayer")]
        public IActionResult AddRatePlayer(int id, [FromBody] PlayerRateDTO playerRate)
        {
            /*var _player = _unitOfWork.Players.GetById(id);
            int playerPossition = (int)_player.PlayerPosition;
            *//*if(_player.PlayerPosition == "GoalKeeper")
            {
                playerPossition = 3;
            }
            else if(_player.Position == "Defender")
            {
                playerPossition = 0;
            }
            else if(_player.Position == "Center")
            {
                playerPossition = 2;
            }*/
            BaseRateDTO player = new()
            {
                defending = playerRate.defending,
                dribbling = playerRate.dribbling,
                shooting = playerRate.shooting,
                pace = playerRate.pace,
                passing = playerRate.passing
            };

            _unitOfWork.Players.AddRate(id, player);
            return Ok();
        }
        [HttpPost("AddRateGK")]
        public IActionResult AddRateGK(int id, [FromBody] GKRateDTO playerRate)
        {
            BaseRateDTO player = new()
            {
                player_possition = 3,
                gk_diving = playerRate.gk_diving,
                gk_speed = playerRate.gk_speed,
                gk_positioning = playerRate.gk_positioning,
                gk_handling = playerRate.gk_handling,
                gk_kicking = playerRate.gk_kicking,
                gk_reflexes = playerRate.gk_reflexes
            };
            _unitOfWork.Players.AddRate(id, player);
            return Ok();
        }
    
    
    }
}
