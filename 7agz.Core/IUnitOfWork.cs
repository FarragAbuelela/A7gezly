using _7agz.Core.Interfaces;
using _7agz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayersRepository Players { get; }
        ITeamRepository Teams { get; }
        IBaseRepository<Stadium> Stadiums { get; }
        IBaseRepository<PlayerData> PlayersData { get; }
        IOwnerRepository StadiumOwners { get; }
        IBaseRepository<ReservedHour> ReservedHours { get; }

        int Complete();
    }
}
