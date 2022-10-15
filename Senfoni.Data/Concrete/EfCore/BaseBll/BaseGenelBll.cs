using Senfoni.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Senfoni.Data.Concrete.EfCore
{
    public class  BaseGenelBll<T> : BaseBll<T, SenfoniContext> where T:BaseEntity
    {
        private string _kodTanimlayici;

        public BaseGenelBll() { }
        public BaseGenelBll(string kodTanimlayici) { _kodTanimlayici = kodTanimlayici; }
        public virtual BaseEntity Single(Expression<Func<T,bool>> filtre)
        {
            return BaseSingle(filtre, x => x);
        }
        public virtual IEnumerable<BaseEntity> List(Expression<Func<T,bool>> filter)
        {
            var list= BaseList(filter, x => x).OrderBy(x => x.Kod).ToList();
            return list;
        }
        public bool Insert(BaseEntity entity,Expression<Func<T,bool>> filter)
        {
            return BaseInsert(entity, filter);
        }
        public bool Insert(BaseEntity entity)
        {
            return BaseInsert(entity, x=>x.Kod==entity.Kod);
        }
        public bool Update(BaseEntity oldEntity,BaseEntity currentEntity)
        {
            return BaseUpdate(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod);
        }
        public bool Update(BaseEntity oldEntity,BaseEntity currentEntity,Expression<Func<T,bool>> filter)
        {
            return BaseUpdate(oldEntity, currentEntity, filter);
        }
        public virtual bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity);
        }
        public string YeniKodVer()
        {
            return BaseYeniKodVer(_kodTanimlayici, x => x.Kod);
        }
        public string YeniKodVer(Expression<Func<T,bool>> filter)
        {
            return BaseYeniKodVer(_kodTanimlayici,x=>x.Kod, filter);
        }
    }
}
