using _7agz.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerData> PlayersData { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<StadiumOwner> StadiumsOwner { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ReservedHour> ReservedHours { get; set; }

        
    }
}
