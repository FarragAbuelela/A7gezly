using _7agz.Core.Consts;
using _7agz.Core.DTOs;
using _7agz.Core.Interfaces;
using _7agz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.EF.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayersRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /*public void Delete(Player player)
        {

            // we need when i delete a player it will be deleted from all relationships
        }*/

        public IEnumerable<PlayerMatchesDTO> MatchDetails(Expression<Func<Player, bool>> criteria)
        {
            #region query 1
            /*Player query = _context.Players.SingleOrDefault(criteria)!;
            var finalQuery = from team in _context.Teams
                             where team.Players.Contains(query)
                             join reservedHour in _context.ReservedHours
                             on team.ReservedHourId equals reservedHour.Id
                             join stadium in _context.Stadiums on
                             team.StadiumId equals stadium.Id
                             select new MatchDetailsDTO
                             {
                                 TeamName = team.Name,
                                 Hour = reservedHour.Time,
                                 StadiumName = stadium.Name,
                                 Longitude = stadium.Longitude,
                                 Latitude = stadium.Latitude,
                                 date = reservedHour.Date,
                                 TeamMembers = team.Players.Select(x => new TeamMembersDTO { Name = x.Name, PhoneNumber = x.PhoneNumber, PlayerEmail = x.Email }).ToList()
                             };
            return finalQuery.ToList();
*/

            #endregion

            var result = _context.Players.Where(criteria).Select(player => new PlayerMatchesDTO
            {
                Email = player.Email, Name = player.Name,PhoneNumber = player.PhoneNumber,

                MatchDetails = player.Teams.Where(p=> p.ReservedHour.ReserverType == false)
                .Select(team => new MatchDetailsDTO
                {
                    TeamName = team.Name, HourPrice = team.ReservedHour.HourPrice,
                    StadiumName = team.Stadium.Name, StadiumLongitude = team.Stadium.Longitude,
                    StadiumLatitude = team.Stadium.Latitude, Date = team.ReservedHour.Date,

                    TeamMembers = team.Players.
                    Select(x => new TeamMembersDTO { id = x.Id,rank = 70m,
                        Name = x.Name, PhoneNumber = x.PhoneNumber, PlayerEmail = x.Email, Position = x.PlayerPosition }).ToHashSet()
                    //StadiumId = team.StadiumId,

                }).ToHashSet()

            });
            return result;


        }


        public void AddRate(int id, BaseRateDTO playerRate)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("https://players-rating.onrender.com");
            List<BaseRateDTO> li = new() { playerRate };
            var result = Client.PostAsJsonAsync("/predict", li).Result;
            string s = result.Content.ReadAsStringAsync().Result.ToString();

            if (result.IsSuccessStatusCode)
            {
                decimal rate = decimal.Parse(s.Substring(1, s.Length - 3));
                var res = _context.PlayersData.Where(p => p.PlayerId == id).FirstOrDefault();
                
                if(res is not null)
                {
                    if(res.player_possition != 3)
                    {
                        if (res.Rank == 0)
                        {
                            res.Rank = rate;
                            res.defending = playerRate.defending;
                            res.pace = playerRate.pace;
                            res.shooting = playerRate.shooting;
                            res.dribbling = playerRate.dribbling;
                            res.passing = playerRate.passing;
                        }
                        else
                        {
                            res.Rank = (res.Rank + rate) / 2.0m;
                            res.defending = (res.defending + playerRate.defending) / 2.0m;
                            res.pace = (res.pace + playerRate.pace) / 2.0m;
                            res.shooting = (res.shooting + playerRate.shooting) / 2.0m;
                            res.dribbling = (res.dribbling + playerRate.dribbling) / 2.0m;
                            res.passing = (res.passing + playerRate.passing) / 2.0m;
                        }
                    }
                    else
                    {
                        if (res.Rank == 0)
                        {
                            res.Rank = rate;
                            res.gk_diving = playerRate.gk_diving;
                            res.gk_speed = playerRate.gk_speed;
                            res.gk_positioning = playerRate.gk_positioning;
                            res.gk_handling = playerRate.gk_handling;
                            res.gk_kicking = playerRate.gk_kicking;
                            res.gk_reflexes = playerRate.gk_reflexes;
                        }
                        else
                        {
                            res.gk_diving += playerRate.gk_diving;
                            res.gk_speed += playerRate.gk_speed;
                            res.gk_positioning += playerRate.gk_positioning;
                            res.gk_handling += playerRate.gk_handling;
                            res.gk_kicking += playerRate.gk_kicking;
                            res.gk_reflexes += playerRate.gk_reflexes;
                            res.gk_diving /=2.0m;
                            res.gk_speed /= 2.0m;
                            res.gk_positioning /= 2.0m;
                            res.gk_handling /= 2.0m;
                            res.gk_kicking /= 2.0m;
                            res.gk_reflexes /= 2.0m;
                        }
                    }
                    _context.SaveChanges();
                }
                
            }
            else
            {
                result.StatusCode.ToString();
            }
        }

        public IEnumerable<Player> GetPlayersByPosition(Position position, DateTime date)
        {
            var result = _context.Players.Where(p => p.PlayerPosition == position).Where(p => p.Teams.Where(t => t.ReservedHour.Date == date).Any() == false).OrderBy(p => p.PlayerData.Rank);

            return result;
        }
    }
}
