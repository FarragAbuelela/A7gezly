using GraduationProjectDemo.DTOs;
using GraduationProjectDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectDemo.Services
{
    public interface IPlayerServices
    {
        IEnumerable<Person> GetAllPlayers();
        Person GetPlayer(int id);
        Person CreatePlayer(Person player);
        Person UpdatePlayer(Person player);
        Person DeletePlayer(Person id);

    }
}
