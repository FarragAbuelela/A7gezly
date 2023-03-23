using _7agz.Core.Consts;
using _7agz.Core.DTOs;
using _7agz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.Interfaces
{
    public interface IPlayersRepository : IBaseRepository<Player>
    {
        IEnumerable<PlayerMatchesDTO> MatchDetails(Expression<Func<Player, bool>> criteria);
        void AddRate(int id, BaseRateDTO playerRate);
        IEnumerable<Player> GetPlayersByPosition(Position position, DateTime date);  
    }
}
