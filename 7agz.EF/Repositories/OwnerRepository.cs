using _7agz.Core.DTOs;
using _7agz.Core.Interfaces;
using _7agz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.EF.Repositories
{
    public class OwnerRepository : BaseRepository<StadiumOwner>, IOwnerRepository
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<StadiumDetailsDTO> StadiumsDetails(int id)
        {
            //throw new NotImplementedException();

            var result = from s in _context.Stadiums
                         where s.Id == id
                         select new StadiumDetailsDTO
                         {
                             StadiumName = s.Name,
                             Price = s.HourPrice,
                             ReservedHours = s.ReservedHours.ToList()
                         };
            return result.ToList();
        }
    }
}
