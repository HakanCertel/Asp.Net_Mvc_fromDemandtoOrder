using Microsoft.EntityFrameworkCore;
using Senfoni.Entity;
using Senfoni.Entity.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Senfoni.Data.Concrete.EfCore
{
    public class BaseUserBll<T, TContext>:IBaseBll  where T:BaseUserEntity where TContext:DbContext
    {
        //private readonly Control _ctrl;
        private  IUnitOfWork<T> _uow;
        
        protected TResult BaseSingle<TResult>(Expression<Func<T,bool>> filter, Expression<Func<T, TResult>> selector)
        {
            GenerealFunctions.CreateUnitOfWork<T,TContext>(ref _uow);
            return _uow.Rep.Find(filter, selector);
        }
        protected IQueryable<TResult> BaseList<TResult>(Expression<Func<T,bool>> filter,Expression<Func<T,TResult>> selector)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            return  _uow.Rep.Select(filter, selector);
        }
        protected bool BaseInsert (BaseEntity entity,Expression<Func<T,bool>> filter)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            _uow.Rep.Insert(entity.EntityConvert<T>());
            return _uow.Save();
        }
        protected bool BaseUpdate(BaseEntity oldEntity,BaseEntity currentEntity,Expression<Func<T,bool>> filter)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            var degisenAlanlar = oldEntity.DegisenAlanlariGetir(currentEntity);
            _uow.Rep.Update(currentEntity.EntityConvert<T>(), degisenAlanlar);
            return _uow.Save();
        }
        protected bool BaseDelete(BaseEntity entity)
        {
            GenerealFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            _uow.Rep.Delete(entity.EntityConvert<T>());
            return _uow.Save();
        }
        protected string BaseYeniKodVer(string kodTanimlayici,Expression<Func<T,string>> filter,Expression<Func<T,bool>> where = null)
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
