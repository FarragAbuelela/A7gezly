using _7agz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.DTOs
{
    public class StadiumDetailsDTO
    {
        public string StadiumName { get; set; }
        public int Price { get; set; }
        public List<ReservedHour> ReservedHours { get; set; }

    }
}
