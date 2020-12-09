using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CS3750FinalTimeTracker
{
    public interface IRepository<T> where T : class
    {

        //Get Object by Id -- doesn't matter what the object is 
        T Get(int id);

        //Get all objects and return as Ienumberable
        IEnumerable<T> GetAll(
            //This filter is evaluated at runtime
            Expression<Func<T, bool>> filter = null,
            //Does the query and returns in ordered
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        //Get the first or default result
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        //Add
        void Add(T entity);

        //Remove by ID
        void Remove(int id);

        //Remove by object type
        void Remove(T entity);

        ////Remove a range or list of objects
        //void RemoveRange(IEnumerable<T> entity);

        void RemoveRange(IEnumerable<T> entity);
    }
}
