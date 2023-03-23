using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.DTOs
{
    public class Pair <TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }
    }
}
