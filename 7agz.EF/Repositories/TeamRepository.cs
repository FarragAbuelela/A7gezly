using _7agz.Core;
using _7agz.Core.Consts;
using _7agz.Core.DTOs;
using _7agz.Core.Interfaces;
using _7agz.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.EF.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<TeamDataDTO> FindTeam(int id)
        {
            // get player id, rank, position
            var player = _context.Players.Where(x => x.Id == id).Select(x => new TeamPlayersDTO
            {
                Id = x.Id,
                position = x.PlayerPosition,
                Rank = x.PlayerData.Rank
            }).FirstOrDefault();
            
            Position position = player!.position;
            decimal Rank = player.Rank;

            //select all teams are not completed
            var result = _context.Teams.Where(t => t.ReservedHour.Date > DateTime.Now 
            && t.Players.Count < 5 && t.ReservedHour.ReserverType == false)
                .Select(x => new TeamDataDTO{ 
                    Id = x.Id,
                    Name = x.Name,
                    ReservedHourId = x.ReservedHourId,
                    StadiumId = x.StadiumId,
                    
                    TeamPlayers = x.Players.Select(p => new TeamPlayersDTO { 
                        Id = p.Id,
                        position = p.PlayerPosition,
                        Rank = p.PlayerData.Rank
                    
                    }).ToHashSet()
                });

            var li = new HashSet<TeamDataDTO>();
            

            //check if he can join this team or not
            foreach (var team in result)
            {
                if(team.TeamPlayers?.Where(x => x.Id == player.Id).Any() == false)
                {
                    break;
                }
                
                var NumberOfplayersAtTheSamePosition = team.TeamPlayers?.Where(p => p.position == position).ToHashSet().Count??0;
               
                var NumberOfTeamPlayers = team.TeamPlayers?.ToHashSet().Count??0;
                
                var SummationOfRanks =
                    team.TeamPlayers?.Select(p => p.Rank).Sum() ?? 0m;
                
                decimal AvgRank = default;
                
                if (NumberOfTeamPlayers > 0)
                {
                    AvgRank = SummationOfRanks / NumberOfTeamPlayers;
                }
                if (Math.Abs(AvgRank - Rank) < 20 && (NumberOfplayersAtTheSamePosition < 1 ||
                    (position == Position.Defender && NumberOfplayersAtTheSamePosition < 2)))
                {
                    li.Add(team);
                }

            }

            //return list of teams he can join
            return li;
        }

        public IEnumerable<Player> JoinTeam(int playerId, int teamId)
        {
            var _player = _context.Players.Where(p => p.Id == playerId).FirstOrDefault();
            _context.Teams.Where(t => t.Id == teamId).FirstOrDefault().Players.Add(_player);
            _context.SaveChanges();
            return _context.Teams.Where(t => t.Id == teamId).FirstOrDefault().Players.ToHashSet();
        }

        public void WithdrawFromTeam(int playerId, int teamId)
        {
            var _player = _context.Players.Where(p => p.Id == playerId).FirstOrDefault();


            
            var _team = (from t in _context.Teams where t.Id == teamId select t).Include(p=>p.Players).FirstOrDefault();
            _team.Players.Remove(_player);
            _context.SaveChanges();

            /*if (_team != null)
            {
                foreach (var player in _team.Players)
                {
                    if(_player.Id == player.Id)
                    {
                        _team.Players.Remove(player);
                    }
                }
            }*/
            //var result = _context.Teams.Where(t => t.Id == teamId).FirstOrDefault().Players.ToHashSet();// Include(p => p.Players).ToHashSet();
            //result.Remove(_player);
            //_player.Teams.Remove(_team);



            //_player.Teams.Remove(_context.Teams.Where(team => team.Id == teamId).FirstOrDefault());
            //_context.Teams.Where(t => t.Id == teamId).FirstOrDefault().Players.Remove(_player.FirstOrDefault());



            //return _context.Teams.Where(t => t.Id == teamId).FirstOrDefault().Players.ToHashSet();
            //throw new NotImplementedException();
        }

        public void CancelHour(int hourId)
        {
            var teams = _context.Teams.Where(t => t.ReservedHourId == hourId);
            _context.Teams.RemoveRange(teams);
            var hour = _context.ReservedHours.Where(h => h.Id == hourId);
            _context.ReservedHours.RemoveRange(hour);
            _context.SaveChanges();

            //throw new NotImplementedException();
        }
    }
}
