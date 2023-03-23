using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.DTOs
{
    public class NearestStadiumDTO
    {
        public double Distance { get; set; }
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

    }
}
