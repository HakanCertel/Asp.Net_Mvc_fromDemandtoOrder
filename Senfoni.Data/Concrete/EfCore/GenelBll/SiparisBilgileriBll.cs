using Senfoni.Data.Concrete.EfCore.BaseBll;
using Senfoni.Entity;
using Senfoni.Entity.Base;
using Senfoni.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Senfoni.Data.Concrete.EfCore.GenelBll
{
    public class SiparisBilgileriBll:BaseHareketBll<SiparisBilgileri,SenfoniContext>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<SiparisBilgileri, bool>> filter)
        {
            return BaseList(filter, x => new SiparisBilgileriL
            {
                Id=x.Id,
                CariId=x.CariId,
                CariAdi=x.Cari.CariAdi,
                CariAdres=x.Cari.Adres,
                KullaniciId=x.KullaniciId,
                KullaniciAdi="",
                KullaniciSoyadi="",
                SiparisId=x.SiparisId,
                SiparisKodu=x.Siparis.Kod,
                StokId=x.StokId,
                StokKodu=x.Stok.Kod,
                StokAdi=x.Stok.StokAdi,
                FiyatBirim=x.Stok.FiyatBirim,
                Fiyat=x.Fiyat,
                TalepMiktari=x.TalepMiktari,
                SiparisTarihi=x.SiparisTarihi,
                TeslimTarihi=x.TeslimTarihi,
                Kapandi=x.Kapandi
            }).AsQueryable().OrderBy(x=>x.SiparisId).ThenBy(x=>x.SiparisTarihi).ToList();
        }
    }
}
