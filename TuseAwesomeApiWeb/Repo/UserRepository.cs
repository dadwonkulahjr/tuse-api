using TuseAwesomeApiWeb.Data;
using TuseAwesomeApiWeb.Models;
using TuseAwesomeApiWeb.Repo.IRepo;

namespace TuseAwesomeApiWeb.Repo
{
    public class UserRepository : GenericRepo<User>, IUser
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void UpdateUser(User userToUpdate)
        {
            var result = _applicationDbContext.Users.Attach(userToUpdate);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _applicationDbContext.SaveChanges();
        }
    }
}
