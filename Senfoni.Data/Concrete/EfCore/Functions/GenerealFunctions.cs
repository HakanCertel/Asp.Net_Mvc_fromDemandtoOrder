using Microsoft.EntityFrameworkCore;
using Senfoni.Data.Concrete.EfCore.BaseBll;
using Senfoni.Entity;
using Senfoni.Entity.Base;
using Senfoni.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senfoni.Data.Concrete.EfCore
{
    public static class GenerealFunctions
    {
        public static void CreateUnitOfWork<T,TContext>(ref IUnitOfWork<T> uow) 
            where T:class,IBaseEntity
            where TContext : DbContext
        {
            uow?.Dispose();
            uow = new UnitOfWork<T>(CerateContext<TContext>());
        }

        private static TContext CerateContext<TContext>() where TContext : DbContext
        {
            return (TContext)Activator.CreateInstance(typeof(TContext)/*, GetConnectionString()*/);
        }

        private static string GetConnectionString()
        {
            return null;
        }

        public static IList<string> DegisenAlanlariGetir<T>(this T oldEntity,T currentEntity)
        {
            IList<string> alanlar = new List<string>();
            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;

                if (oldEntity.GetType().GetProperty(prop.Name) == null) continue;

                var oldValue = prop.GetValue(oldEntity)?? string.Empty;

                var currentValue = prop.GetValue(currentEntity)?? string.Empty;

                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString()))
                        oldValue = new byte[] { 0 };
                    if (string.IsNullOrEmpty(currentValue.ToString()))
                        currentValue = new byte[] { 0 };
                    if (((byte[])oldValue).Length != ((byte[])currentValue).Length)
                        alanlar.Add(prop.Name);
                }
                else if (!currentValue.Equals(oldValue))
                    alanlar.Add(prop.Name);
            }
            return alanlar;
        }

        public static IEnumerable<TEntity> CreateInstanceOfHareketBll<TBll, TEntity>(long id) where TEntity: BaseEntity where TBll: BaseGenelBll<TEntity>
        {
            using (var bll = (TBll)Activator.CreateInstance(typeof(TBll)))
            {
                return bll.List(x=>x.Id==id).EntityListConvert<TEntity>();
            }
        }
        public static TBll CreateInstanceOfBll<TBll>() where TBll : IBaseBll
        {
            using (var bll = (TBll)Activator.CreateInstance(typeof(TBll)))
            {
                return bll;
            }
        }

        public static IEnumerable<TResult> ListelenecekKayitlar<TResult,TBll>(this List<long> listeDisiTutulacakKayitlar) where TBll:BaseGenelBll<TResult> where TResult:BaseEntity
        {
            IEnumerable<TResult> listelenecekKayitlar= new List<TResult>();
            using (var Bll =(TBll)Activator.CreateInstance(typeof(TBll)))
            {
                if (listeDisiTutulacakKayitlar != null)
                {
                    listelenecekKayitlar = Bll.List(x => !listeDisiTutulacakKayitlar.Contains(x.Id)).EntityListConvert<TResult>().ToList();
                }
                else
                    listelenecekKayitlar = Bll.List(null).Cast<TResult>();

                return listelenecekKayitlar;
            }
        }
        public static StokS FindStok(long id)
        {
            using (var bll = new StokBll())
            {
                return bll.Single(x => x.Id == id).EntityConvert<StokS>();
            }
        }
    }
}
