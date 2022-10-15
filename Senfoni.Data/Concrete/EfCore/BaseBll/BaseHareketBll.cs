using Microsoft.EntityFrameworkCore;
using Senfoni.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Senfoni.Data.Concrete.EfCore.BaseBll
{
    public class BaseHareketBll<T,TContext>:IBaseBll where T:BaseHareketEntity where TContext:DbContext
    {
        private IUnitOfWork<T> _uow;

        protected TResult BaseSingle<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            return _uow.Rep.Find(filter, selector);
        }
        public IQueryable<TResult> BaseList<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            return _uow.Rep.Select(filter, selector);
        }
        public bool BaseInsert(IEnumerable<BaseHareketEntity> entities)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            _uow.Rep.Insert(entities.EntityListConvert<T>());
            return _uow.Save();
        }
        protected bool BaseInsert(BaseHareketEntity entity)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            _uow.Rep.Insert(entity.EntityConvert<T>());
            return _uow.Save();
        }
        public bool BaseUpdate(IEnumerable<BaseHareketEntity> entities)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            _uow.Rep.Update(entities.EntityListConvert<T>());
            return _uow.Save();
        }
        public bool BaseDelete(BaseHareketEntity entity)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            _uow.Rep.Delete(entity.EntityConvert<T>());
            return _uow.Save();
        }
        protected bool BaseDelete(IEnumerable<BaseHareketEntity> entities)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            _uow.Rep.Delete(entities.EntityListConvert<T>());
            return _uow.Save();
        }
        protected string BaseYeniKodVer(string kodTanimlayici, Expression<Func<T, string>> filter, Expression<Func<T, bool>> where = null)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            return _uow.Rep.YeniKodVer(kodTanimlayici, filter, where);
        }
        public void Dispose()
        {
            _uow?.Dispose();
        }
    }
}
