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
    }
}
