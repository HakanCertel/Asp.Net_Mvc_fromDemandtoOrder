using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Senfoni.Data.Concrete.EfCore
{
    public class Repository<T> : IRepositoryy<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            if (context == null) return;
            _context = context;
            _dbSet = context.Set<T>();
        }
        public TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            return filter == null ? _dbSet.Select(selector).FirstOrDefault() : _dbSet.Where(filter).Select(selector).FirstOrDefault();
        }
        public IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            return filter == null ? _dbSet.Select(selector) : _dbSet.Where(filter).Select(selector);
        }
        public void Insert(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Added;
            }
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(T entity, IEnumerable<string> fields)
        {
            _context.Attach(entity);
            var entry = _context.Entry(entity);
            foreach (var field in fields)
            {
                entry.Property(field).IsModified = true;
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            return filter == null ? _dbSet.Count() : _dbSet.Count(filter);
        }
        public string YeniKodVer(string kodTanimlayici, Expression<Func<T, string>> filter, Expression<Func<T, bool>> where = null)
        {
            string Kod()//bu metod işlem yaptığımız tabloda veri yoksa bu metod çalışarak ilk kodu verecektir.....
            {
                string kod = null;
                var kodDizi = kodTanimlayici.Split(' ');//bu ifade,string ifade içinde, diziyi herboşluk sonrası kaç adet ifade olamasına göre ayıracak

                for (int i = 0; i < kodDizi.Length; i++)
                {
                    kod += kodDizi[i];

                    if (i + 1 < kodDizi.Length - 1)
                        kod += " ";
                }

                return kod += "000000001";
            }

            string YeniKodVer(string kod)
            {
                var sayisalDegerler = "";

                foreach (var karakter in kod)
                {
                    if (char.IsDigit(karakter))
                        sayisalDegerler += karakter;
                    else
                        sayisalDegerler = "";
                }

                var artisSonrasiDeger = (int.Parse(sayisalDegerler) + 1).ToString();
                var fark = kod.Length - artisSonrasiDeger.Length;
                if (fark < 0)
                    fark = 0;

                var yeniDeger = kod.Substring(0, fark);
                yeniDeger += artisSonrasiDeger;
                return yeniDeger;

            }

            var maxKod = where == null ? _dbSet.Max(filter) : _dbSet.Where(where).Max(filter);
            return maxKod == null ? Kod() : YeniKodVer(maxKod);
        }


        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
