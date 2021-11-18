using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult RetrievedAllUserData()
        {
            return Json(new { name = "iamtuse", occupation = "Developer!" });
        }
    }
}
