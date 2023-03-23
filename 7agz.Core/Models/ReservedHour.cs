using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.Models
{
    public class ReservedHour
    {

        public ReservedHour()
        {
            Teams = new HashSet<Team>();
        }
        public int Id {get;set;}
        public DateTime Date { get; set; }
        public int HourPrice { get; set; }
        public int Time { get; set; }
        public int ReserverId { get; set; }
        public bool ReserverType { get; set; }
        public int? StadiumId { get; set; }
        //public virtual Stadium Stadiums { get; set; }
        public virtual ICollection<Team> Teams { get; set; }


    }
}
