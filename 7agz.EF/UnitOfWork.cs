using _7agz.Core;
using _7agz.Core.Interfaces;
using _7agz.Core.Models;
using _7agz.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IPlayersRepository Players { get; private set; }
        public ITeamRepository Teams { get; private set; }
        public IBaseRepository<Stadium> Stadiums { get; private set; }
        public IBaseRepository<PlayerData> PlayersData { get; private set; }
        public IOwnerRepository StadiumOwners { get; private set; }
        public IBaseRepository<ReservedHour> ReservedHours { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Players = new PlayerRepository(_context);
            StadiumOwners = new OwnerRepository(_context);
            Teams = new TeamRepository(_context);
            Stadiums = new BaseRepository<Stadium>(_context);
            PlayersData = new BaseRepository<PlayerData>(_context);
            ReservedHours = new BaseRepository<ReservedHour>(_context);
        }

       
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
