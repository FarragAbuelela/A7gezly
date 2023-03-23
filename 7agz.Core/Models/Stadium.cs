using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.Models
{
    public class Stadium
    {
        public Stadium()
        {
            Teams = new HashSet<Team>();
            ReservedHours = new HashSet<ReservedHour>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int HourPrice { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int Capacity { get; set; }
        public bool Vestiary { get; set; }
        public bool Cafeteria { get; set; }
        public bool ParkingArea { get; set; }
        public int StadiumOwnerId { get; set; }
        public virtual StadiumOwner StadiumOwner { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<ReservedHour> ReservedHours { get; set; }
    }
}
