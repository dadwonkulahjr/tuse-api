using System;
using System.Collections.Generic;
using System.Linq;

namespace TuseAwesomeApiWeb.Repo.IRepo
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAllItems();
        IEnumerable<T> FilterItems(Func<T, bool> filterItem = null);
        IEnumerable<T> SortItems(Func<IQueryable<T>, IOrderedQueryable<T>> filterItems = null);

        IEnumerable<T> GetNavigationPropertiesIfAny(string navigationProperties = null);

        T GetSingleOrDefaultItem(Guid id);

        T AddAnItem(T itemToAdd);
    }
}
