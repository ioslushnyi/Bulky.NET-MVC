using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;
using System.Linq.Expressions;
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DBSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            DBSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            DBSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = DBSet.AsQueryable();
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DBSet.AsQueryable();
            //query.Where(filter);
            return query.Where(filter).FirstOrDefault();
        }

        public void Remove(T entity)
        {
            DBSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DBSet.RemoveRange(entities);
        }
    }
}
