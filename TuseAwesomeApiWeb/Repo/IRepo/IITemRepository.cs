using TuseAwesomeApiWeb.Models;

namespace TuseAwesomeApiWeb.Repo.IRepo
{
    public interface IITemRepository : IGenericRepo<Item>
    {
        void UpdateItem(Item itemToUpdate);
    }
}
