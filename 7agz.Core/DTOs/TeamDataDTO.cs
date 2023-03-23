using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.DTOs
{
    public class TeamDataDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StadiumId { get; set; }
        public int ReservedHourId { get; set; }
        public double Distance { get; set; }
        public HashSet<TeamPlayersDTO> TeamPlayers { get; set; }= new HashSet<TeamPlayersDTO>();
    }
}
