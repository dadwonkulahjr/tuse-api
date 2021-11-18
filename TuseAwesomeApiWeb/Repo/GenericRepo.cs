using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TuseAwesomeApiWeb.Repo.IRepo;

namespace TuseAwesomeApiWeb.Repo
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        internal DbSet<TEntity> _query;
        internal DbContext _context;
        public GenericRepo(DbContext dbContext)
        {
            _query = dbContext.Set<TEntity>();
            _context = dbContext;
        }
        public TEntity AddAnItem(TEntity itemToAdd)
        {
            _query.Add(itemToAdd);
            return itemToAdd;
        }

        public void Delete(int id)
        {
            var findEntity = _query.Find(id);

            if (findEntity != null)
            {
                _query.Remove(findEntity);
            }
        }

        public void Delete(TEntity typeToDelete)
        {
            _context.Remove(typeToDelete);
        }

        public IEnumerable<TEntity> FilterItems(Func<TEntity, bool> filterItem = null)
        {
            IQueryable<TEntity> myQuery = _query;

            if (filterItem != null)
            {
                return myQuery.Where(filterItem).ToList();
            }


            return myQuery.ToList();
        }

        public IEnumerable<TEntity> GetAllItems()
        {
            return _query.ToList();
        }

        public IEnumerable<TEntity> GetNavigationPropertiesIfAny(string navigationProperties = null)
        {
            IQueryable<TEntity> myQuery = _query;
            if (navigationProperties != null)
            {
                foreach (var property in navigationProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    myQuery = myQuery.Include(property);
                }

            }

            return myQuery.ToList();
        }

        public TEntity GetSingleOrDefaultItem(Guid id)
        {
            return _query.Find(id);
        }

        public IEnumerable<TEntity> SortItems(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> filterItems = null)
        {
            IQueryable<TEntity> myQuery = _query;


            if (filterItems != null)
            {
                return filterItems(myQuery).ToList();
            }


            return myQuery.ToList();

        }
    }
}
