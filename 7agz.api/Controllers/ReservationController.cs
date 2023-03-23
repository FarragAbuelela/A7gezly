using _7agz.Core;
using _7agz.Core.Consts;
using _7agz.Core.DTOs;
using _7agz.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Runtime.InteropServices;

namespace _7agz.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("FindStadium")]
        public IActionResult NearestStadium(decimal latitude, decimal longitude, double distance = 1000)
        {
            var stadiums = _unitOfWork.Stadiums.GetAll();
            List<NearestStadiumDTO> nearestStdaiums = new List<NearestStadiumDTO>();
            foreach(var stadium in stadiums)
            {
                
                var far = Distance(latitude,longitude,stadium.Latitude,stadium.Longitude);
                if (far <= distance || distance == -1) nearestStdaiums.Add(new NearestStadiumDTO { 
                    Distance = far,
                    Cafeteria = stadium.Cafeteria,
                    Capacity = stadium.Capacity,
                    End = stadium.End,
                    HourPrice = stadium.HourPrice,
                    Id = stadium.Id,
                    Latitude = stadium.Latitude,
                    Longitude = stadium.Longitude,
                    Name = stadium.Name,
                    ParkingArea = stadium.ParkingArea,
                    StadiumOwnerId = stadium.StadiumOwnerId,
                    Start = stadium.Start,
                    Vestiary = stadium.Vestiary
                });
            }

            
            return Ok(nearestStdaiums.OrderBy(s => s.Distance));

            #region Comment

            /*
                        decimal res = Convert.ToDecimal(3959 * Math.Acos(Math.Cos(latA) * Math.Cos(latB) *
                            Math.Cos(longB - longB) + Math.Sin(latA) *
                            Math.Sin(longB)));

                        return Ok(res);*/
            /*
                        string url = $"https://maps.googleapis.com/maps/api/distancematrix/";

                        var clinet = new RestClient(url);
                        var response = clinet.Execute(new RestRequest().AddJsonBody
                            ( new Post(latitude, longitude, result.Latitude, result.Longitude)));
                        return Ok(response);
            */
            #endregion
        }

        [HttpPost("ReserveStadium")]
        public IActionResult ReserveStadium(ReservationDTO ReservationData)
        {
            #region reservation
            //reserve hour
            var reservedHour = _unitOfWork.ReservedHours.Add(new()
            {
                Date = ReservationData.ReservedHour,
                StadiumId = ReservationData.StadiumId,
                ReserverId = ReservationData.ReserverId,
                ReserverType = ReservationData.ReserverType,
                HourPrice = _unitOfWork.Stadiums.GetById(ReservationData.StadiumId).HourPrice
            });

            HashSet<Player> Team1Players = _unitOfWork.Players.GetAll().Where(x => ReservationData.TeamMembers1.Contains(x.Id)).ToHashSet<Player>();
            HashSet<Player> Team2Players = _unitOfWork.Players.GetAll().Where(x => ReservationData.TeamMembers2.Contains(x.Id)).ToHashSet<Player>();

            var team1 = _unitOfWork.Teams.Add(new Team { StadiumId = ReservationData.StadiumId, Name = "team1", ReservedHourId = reservedHour.Id, Players = Team1Players });
            var team2 = _unitOfWork.Teams.Add(new Team { StadiumId = ReservationData.StadiumId, Name = "team2", ReservedHourId = reservedHour.Id, Players = Team2Players });

            #endregion


            return Ok(/*new { team1, team2 }*/
                _unitOfWork.Players.MatchDetails(p=> p.Id == ReservationData.ReserverId)
                );
        }

        [HttpPost("ReserveStadiumOwner")]
        public IActionResult ReserveStadiumOwner(ReservationOwnerDTO ReservationData)
        {
            var result =  _unitOfWork.ReservedHours.Add(new()
            {
                Date = ReservationData.ReservedHour,
                StadiumId = ReservationData.StadiumId,
                ReserverId = ReservationData.ReserverId,
                ReserverType = ReservationData.ReserverType,
                HourPrice = _unitOfWork.Stadiums.GetById(ReservationData.StadiumId).HourPrice
            });
            return Ok(result);
        }



        [HttpGet("FindTeam")]
        public IActionResult FindTeam(int id, decimal latitude, decimal longitude, double distance = 1000)
        {
            #region Comment
            /*var Hours = _unitOfWork.ReservedHours.GetAll().Where(hour => hour.Date > DateTime.Now && hour.ReserverType == false);
            foreach (var hour in Hours)
            {
                hour.Teams
            }*/
            /*var player = _unitOfWork.Players.Find(x => x.Id == id);
            var result = 
                _unitOfWork.Teams.GetAll().
                Where(t => t.ReservedHour.Date > DateTime.Now &&
                t.Players.Count < 5 && t.ReservedHour.ReserverType == false);

            var li = new HashSet<Team>();
            foreach (var team in result)
            {
                var res = team.Players.Where(p => p.Position == player.Position);
                var SummationOfRanks = 
                    team.Players?.Select(p => p.PlayerData.Rank).Sum()??0m;
                int NumberOfPlayers = res?.ToHashSet().Count ?? 0;
                decimal AvgRank = default;
                if(NumberOfPlayers > 0)
                {
                    AvgRank = SummationOfRanks / NumberOfPlayers;
                }
                if(Math.Abs(AvgRank - player.PlayerData.Rank) < 15 && (NumberOfPlayers < 1 || 
                    (player.Position == "Definder" && NumberOfPlayers < 2)))
                {
                    li.Add(team);
                }

            }*/
            #endregion

            var result = _unitOfWork.Teams.FindTeam(id).ToHashSet();
            var finalResult = new HashSet<TeamDataDTO>();
            foreach(var item in result)
            {
                var staduim = _unitOfWork.Stadiums.Find(s => s.Id == item.StadiumId);
                double dis = Distance(latitude, longitude, staduim.Latitude, staduim.Longitude);
                if(dis <= distance)
                {
                    item.Distance = dis;
                    finalResult.Add(item);
                }
            }
            return Ok(finalResult.OrderBy(t => t.Distance));


        }


        [HttpPost("JoinTeam")]
        public IActionResult JoinTeam(int playerId, int teamId)
        {
            return Ok(_unitOfWork.Teams.JoinTeam(playerId, teamId));
        }


        [HttpDelete("WithdrawTeam")]
        public IActionResult WithdrawTeam(int playerId, int teamId)
        {

            _unitOfWork.Teams.WithdrawFromTeam(playerId, teamId);
            return Ok();
        }

        [HttpDelete("CancelReservation")]
        public IActionResult CancelReservation(int hourId)
        {
            _unitOfWork.Teams.CancelHour(hourId);
            return Ok();
        }



        private double Distance(decimal latitude, decimal longitude, decimal Slatitude, decimal Slongitude)
        {

            double latA = Convert.ToDouble(latitude) * 0.0174532925;
            double longA = Convert.ToDouble(longitude) * 0.0174532925;
            double latB = Convert.ToDouble(Slatitude) * 0.0174532925;
            double longB = Convert.ToDouble(Slongitude) * 0.0174532925;

            double dlat = latB - latA;
            double dlong = longB - longA;

            var a = Math.Pow(Math.Sin(dlat / 2.0), 2) + Math.Cos(latA) * Math.Cos(latB) * Math.Pow(Math.Sin(dlong / 2.0), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return (6373.0 * c * 1000);
        }
    }
}
