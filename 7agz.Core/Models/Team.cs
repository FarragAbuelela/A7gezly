using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.Models
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StadiumId { get; set; }
        public int ReservedHourId { get; set; }
        public virtual ReservedHour ReservedHour { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
