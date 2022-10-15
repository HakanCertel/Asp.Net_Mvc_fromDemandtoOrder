using Microsoft.EntityFrameworkCore;
using Senfoni.Data.Concrete.EfCore.Functions;
using Senfoni.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Senfoni.Data.Concrete.EfCore
{
    public class BaseBll<T, TContext>:IBaseBll  where T:BaseEntity where TContext:DbContext
    {
        //private readonly Control _ctrl;
        private  IUnitOfWork<T> _uow;
        private bool Validation(Expression<Func<T, bool>> filter)
        {
            var errorControl = GetValidationErrorControl();

            if (errorControl == null) return true;
            //_ctrl.Controls[errorControl].Focus();
            return false;

            string GetValidationErrorControl()
            {
                string MukerrerKod()
                {
                    foreach (var property in typeof(T).GetPropertyAtributesFromType<Kod>())
                    {
                        if (property.Attribute == null) continue;
                        //if ((islemTuru == IslemTuru.EntityInsert || oldEntity.Kod == currentEntity.Kod) && islemTuru == IslemTuru.EntityUpdate) continue;
                        if (_uow.Rep.Count(filter) < 1) continue;

                        //Messages.MukerrerKayitHataMesaji(property.Attribute.Description);
                        return property.Attribute.ControlName;
                    }

                    return null;
                }

                return  MukerrerKod();
            }

        }
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
            if (!Validation(filter)) return false;
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
