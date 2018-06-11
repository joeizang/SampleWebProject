using SampleWebProject.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SampleWebProject.Persistence
{
    public class Repository<T> : IRepo<T>, IDisposable where T : class
    {
        private readonly DbContext _db;
        private DbSet<T> _set;

        public Repository(DbContext db)
        {
            _db = db;
            _set = _db.Set<T>();
        }


        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void AddRange(IList<T> entities)
        {
            _set.AddRange(entities);
        }

        public T FindById(int id)
        {
            return _set.Find(id);
        }

        public IList<T> GetAll()
        {
            return _set.ToList();
        }

        public IList<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            return _set.Where(predicate).ToList();
        }

        public void Remove(T entity)
        {
            _set.Remove(entity);
        }

        public void RemoveRange(IList<T> entities)
        {
            _set.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}