using _7agz.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.DTOs
{
    public class TeamMembersDTO
    {
        public int id { get; set; }
        public decimal rank { get; set; }
        public string PlayerEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }

    }
}
