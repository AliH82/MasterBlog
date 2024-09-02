using _01_Framework.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Infrastructure
{
    public interface IRepository<TKey, T> where T : BaseDomian
    {
        void Create(T entity);
        T Get(TKey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T, bool>> expression);
        //void Save();
    }
}
