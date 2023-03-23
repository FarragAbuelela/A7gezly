using GraduationProjectDemo.DTOs;
using GraduationProjectDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace GraduationProjectDemo.Services
{
    public class PlayerServices : IPlayerServices
    {
        private readonly ApplicationDbContext _context;

        public PlayerServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public Person CreatePlayer(Person player)
        {
            _context.persons.Add(player);
            _context.SaveChanges();
            return player;
        }

        public Person DeletePlayer(Person player)
        {
            _context.Remove(player);
            _context.SaveChanges();
            return player;
        }

        public IEnumerable<Person> GetAllPlayers() => _context.persons.ToList();

        public Person GetPlayer(int id) => _context.persons.Where(p => p.Id == id).FirstOrDefault();

        public Person UpdatePlayer(Person player)
        {
            _context.Update(player);
            _context.SaveChanges();
            return player;
        }
    }
}
