using _01_Framework.Domian;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _01_Framework.Infrastructure
{
    public class Repository<TKey, T> : IRepository<TKey, T> where T : BaseDomian
    {
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }
    }
}
