using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Senfoni.Data.Concrete.EfCore
{
    public interface IRepositoryy<T>:IDisposable where T:class
    {
        TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);
        IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(T entity, IEnumerable<string> fields);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        int Count(Expression<Func<T, bool>> filter);
        string YeniKodVer(string kodTanimlayici,Expression<Func<T, string>> filter, Expression<Func<T, bool>> where = null);
    }
}
