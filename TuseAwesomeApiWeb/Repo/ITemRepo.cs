using System.Linq;
using TuseAwesomeApiWeb.Data;
using TuseAwesomeApiWeb.Models;
using TuseAwesomeApiWeb.Repo.IRepo;

namespace TuseAwesomeApiWeb.Repo
{
    public class ITemRepo : GenericRepo<Item>, IITemRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ITemRepo(ApplicationDbContext context)
            : base(context)
        {
            _applicationDbContext = context;
        }
        public void UpdateItem(Item itemToUpdate)
        {
            var result = _applicationDbContext.Items.Update(itemToUpdate);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }
    }
}
