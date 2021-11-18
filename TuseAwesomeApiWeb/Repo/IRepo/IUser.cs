using TuseAwesomeApiWeb.Models;

namespace TuseAwesomeApiWeb.Repo.IRepo
{
    public interface IUser : IGenericRepo<User>
    {
        void UpdateUser(User userToUpdate);
    }
}
