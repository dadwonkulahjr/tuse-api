using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuseAwesomeApiWeb.Repo.IRepo;

namespace TuseAwesomeApiWeb.Pages.Admin.User
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Models.User> Users { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }      


        public void OnGet()
        {

            Users = _unitOfWork.UserRepository.SortItems(x => x.OrderBy(x => x.Username))
                                              .ToList();
        }
    }
}
