using _7agz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.DTOs
{
    public class MatchDetailsDTO
    {
        
        public string TeamName { get; set; }
        public string StadiumName { get; set; }
        public int HourPrice { get; set; }
        public decimal StadiumLatitude { get; set; }
        public decimal StadiumLongitude { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public HashSet<TeamMembersDTO> TeamMembers { get; set; }
    }
}
