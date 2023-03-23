using _7agz.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.DTOs
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string street { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Position PlayerPosition { get; set; }
    }
}
