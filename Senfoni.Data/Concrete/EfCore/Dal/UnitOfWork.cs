using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace Senfoni.Data.Concrete.EfCore
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            if (context == null) return;
            _context = context;
        }

        public IRepositoryy<T> Rep => new Repository<T>(_context);

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlEx = (SqlException)ex.InnerException?.InnerException;
                if (sqlEx == null)
                {
                    //Messages.HataMesaji(ex.Message);
                    return false;
                }
                switch (sqlEx.Number)
                {
                    case 208:
                        //Messages.HataMesaji("İşlem Yapmak İstediğiniz Tablo Veritabanında Bulunamadı.");
                        break;
                    case 547:
                        //Messages.HataMesaji(sqlEx.Message/*"Seçilen Kartın İşlem Görmüş Hareketleri Var, Kart Silinemez."*/);
                        break;
                    case 2601:
                    case 2627:
                        //Messages.HataMesaji("Girmiş olduğunuz Id Daha Önce Kullanılmıştır.");
                        break;
                    case 4060:
                        //Messages.HataMesaji("İşlem Yapmak İstediğiniz Veritabanı Sunucuda Bulunamadı.");
                        break;
                    case 18456:
                        //Messages.HataMesaji("Server'a bağlanılmak İstenen Kullanıcı Adı ve Şifre Hatalıdır.");
                        break;
                    default:
                        //Messages.HataMesaji(sqlEx.Message);
                        break;
                }
                return false;
            }
            return true;
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
