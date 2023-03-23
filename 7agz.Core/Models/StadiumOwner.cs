using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.Models
{
    public class StadiumOwner
    {
        public StadiumOwner()
        {
            Stadiums = new HashSet<Stadium>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string street { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Stadium> Stadiums { get; set; }
    }
}
