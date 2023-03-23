using _7agz.Core.Consts;
using _7agz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.DTOs
{
    public class TeamPlayersDTO
    {
        public int Id { get; set; }
        public decimal Rank { get; set; }
        public Position position { get; set; }
    }
}
