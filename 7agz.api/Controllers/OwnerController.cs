using _7agz.Core;
using _7agz.Core.DTOs;
using _7agz.Core.Models;
using _7agz.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace _7agz.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        //yehia comment test
        private readonly IUnitOfWork _unitOfWork;
        
        public OwnerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO owner)
        {

            var result = _unitOfWork.StadiumOwners.Find(_owner => _owner.Email == owner.Email && _owner.Password == owner.Password);
            if (result is null)
            {
                return NotFound("The user name or password does not correct !!!");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_unitOfWork.StadiumOwners.GetById(id));

        [HttpGet("GetAll")]
        public IActionResult GetAll() => Ok(_unitOfWork.StadiumOwners.GetAll());

        [HttpPost]
        public IActionResult Add([FromBody] OwnerDTO owner)
        {
            var check = _unitOfWork.StadiumOwners.Find(_owner => _owner.Email == owner.Email);
            if (check is not null)
            {
                return BadRequest("This account is already exist!!!");
            }

            StadiumOwner _owner = new()
            {
                Name = owner.Name,
                PhoneNumber = owner.PhoneNumber,
                Email = owner.Email,
                Birthdate = owner.Birthdate,
                Country = owner.Country,
                City = owner.City,
                Password = owner.Password,
                street = owner.street
            };

            var result = _unitOfWork.StadiumOwners.Add(_owner);
            Services.SendRegisterationEmail(_owner.Email, _owner.Name);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public IActionResult EditOwner(int id, [FromBody] JsonPatchDocument owner)
        {
            var _owner = _unitOfWork.StadiumOwners.GetById(id);
            if (_owner is null)
            {
                return NotFound();
            }
            return Ok(_unitOfWork.StadiumOwners.Update(id, owner));

        }


        [HttpPut("id")]
        public IActionResult UpdateByPut(int id, [FromBody] OwnerDTO owner)
        {
            var _owner = _unitOfWork.StadiumOwners.GetById(id);
            if (_owner is null) return NotFound();
            if (_owner.Email != owner.Email)
            {
                return BadRequest("Changing E-mail does not allowed !!!");
            }
            _owner.Name = owner.Name;
            _owner.Birthdate = owner.Birthdate;
            _owner.City = owner.City;
            _owner.Country = owner.Country;
            _owner.Email = owner.Email;
            _owner.Password = owner.Password;
            _owner.PhoneNumber = owner.PhoneNumber;
            _owner.street = owner.street;
            return Ok(_unitOfWork.StadiumOwners.UpdateByPut(id, _owner));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var _Owner = _unitOfWork.StadiumOwners.GetById(id);
            if (_Owner is null) return NotFound();
            _unitOfWork.StadiumOwners.Delete(_Owner);
            return StatusCode(NoContent().StatusCode);
        }

        [HttpGet("getStadiums")]
        public IActionResult GetStadiums(int id)
        {
            var result = _unitOfWork.Stadiums.FindAll(stadium => stadium.StadiumOwnerId == id);
            return Ok(result);
        }

    }
}
