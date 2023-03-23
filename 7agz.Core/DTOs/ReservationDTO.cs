using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.DTOs
{
    public class ReservationDTO
    {
        public ReservationDTO()
        {
            TeamMembers1 = new HashSet<int>();
            TeamMembers2 = new HashSet<int>();
        }
        public int StadiumId { get; set; }
        public DateTime ReservedHour { get; set; }
        public int ReserverId { get; set; }
        public bool ReserverType { get; set; }

        public ICollection<int> TeamMembers1 { get; set; }
        public ICollection<int> TeamMembers2 { get; set; }
    }
}
