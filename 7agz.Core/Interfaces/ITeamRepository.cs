using _7agz.Core.DTOs;
using _7agz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.Interfaces
{
    public interface ITeamRepository : IBaseRepository<Team>
    {
        IEnumerable<TeamDataDTO> FindTeam(int id);
        IEnumerable<Player> JoinTeam(int playerId, int teamId);
        void WithdrawFromTeam(int playerId, int teamId);
        void CancelHour(int hourId);
    }
}
