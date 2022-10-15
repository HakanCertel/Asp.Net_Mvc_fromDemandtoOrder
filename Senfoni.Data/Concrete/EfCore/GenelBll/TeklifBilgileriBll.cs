using Senfoni.Data.Concrete.EfCore.BaseBll;
using Senfoni.Entity;
using Senfoni.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Senfoni.Data.Concrete.EfCore.GenelBll
{
    public class TeklifBilgileriBll:BaseHareketBll<TeklifBilgileri,SenfoniContext>
    {
        public IEnumerable<TeklifBilgileri> List(Expression<Func<TeklifBilgileri,bool>> filter)
        {
            return BaseList(filter, x => new TeklifBilgileriL
            {
                Id=x.Id,
                TeklifId=x.TeklifId,
                TeklifKodu=x.Teklif.Kod,
                CariId=x.Teklif.CariId,
                CariAdi=x.Teklif.Cari.CariAdi,
                CariAdres=x.Teklif.Cari.Adres,
                KullaniciId=x.KullaniciId,
                //KullaniciAdi=x.Kullanici.FirstName,
                //KullaniciSoyadi=x.Kullanici.LastName,
                StokId=x.StokId,
                StokKodu=x.Stok.Kod,
                StokAdi=x.Stok.StokAdi,
                FiyatBirim=x.Stok.FiyatBirim,
                Fiyat=x.Stok.Fiyat,
                SipariseDonustumu=x.SipariseDonustumu,
                TalepMiktari=x.TalepMiktari,
                SiparisTarihi=x.SiparisTarihi,
                TeslimTarihi=x.TeslimTarihi,
                Update=true
            });
        }
    }
}
