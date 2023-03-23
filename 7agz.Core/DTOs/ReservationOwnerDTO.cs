using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.DTOs
{
    public class ReservationOwnerDTO
    {
        public int StadiumId { get; set; }
        public DateTime ReservedHour { get; set; }
        public int ReserverId { get; set; }
        public bool ReserverType { get; set; }
    }
}
