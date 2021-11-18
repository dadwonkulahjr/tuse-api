using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TuseAwesomeApiWeb.Dtos;
using TuseAwesomeApiWeb.Extentions;
using TuseAwesomeApiWeb.Models;
using TuseAwesomeApiWeb.Repo.IRepo;

namespace TuseAwesomeApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<UserDto> RetrievedAllUserData()
        {
            return _unitOfWork.UserRepository.GetAllItems()
                                    .Select(x => x.AsUserDto())
                                    .OrderBy(x => x.Username)
                                    .ToList();
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateUserDto userDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }


            if (userDto != null)
            {
                var newUser = new User()
                {
                    Username = userDto.Username,
                    Password = userDto.Password,
                    Email = userDto.Email
                };

                var result = _unitOfWork.UserRepository.AddAnItem(newUser);
                _unitOfWork.Save();

                return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
            }


            return BadRequest();
        }


        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            var findUser = _unitOfWork.UserRepository.FilterItems(x => x.Id == id);

            if (findUser != null)
            {
                return Ok(findUser);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var findExistingUser = _unitOfWork.UserRepository.FilterItems(u => u.Id == id)
                                                             .FirstOrDefault();

            if(findExistingUser is null)
            {
                return NotFound();
            }

            var updateUser = new User()
            {
                Id = id,
                Username = updateUserDto.Username,
                Password = updateUserDto.Password,
                Email = updateUserDto.Email
            };

            _unitOfWork.UserRepository.UpdateUser(updateUser);

            return NoContent();
        }




    }
}
