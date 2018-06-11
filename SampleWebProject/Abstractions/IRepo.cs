using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebProject.Abstractions
{
    public interface IRepo<T> where T : class
    {
        void Add(T entity);

        void AddRange(IList<T> entities);

        void Remove(T entity);

        void RemoveRange(IList<T> entities);

        T FindById(int id);

        IList<T> GetAll();

        IList<T> GetByPredicate(Expression<Func<T, bool>> predicate);

        void Update(T entity);

        int Commit();
    }
}
