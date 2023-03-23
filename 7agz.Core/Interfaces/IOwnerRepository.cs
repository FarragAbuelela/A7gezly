using _7agz.Core.DTOs;
using _7agz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.Interfaces
{
    public interface IOwnerRepository : IBaseRepository<StadiumOwner>
    {
        IEnumerable<StadiumDetailsDTO> StadiumsDetails(int id);
    }
}
