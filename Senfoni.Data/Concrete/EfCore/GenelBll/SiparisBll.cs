using Senfoni.Entity;
using Senfoni.Entity.Dto;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace Senfoni.Data.Concrete.EfCore.GenelBll
{
    public class SiparisBll:BaseGenelBll<Siparis>
    {
        public SiparisBll():base("SP"){}

        public override BaseEntity Single(Expression<Func<Siparis, bool>> filtre)
        {
            return BaseSingle(filtre, x => new SiparisS
            {
                Id=x.Id,
                Kod=x.Kod,
                CariId=x.CariId,
                CariAdi=x.Cari.CariAdi,
                CariAdres=x.Cari.Adres,
                KullaniciId=x.KullaniciId,
                KullaniciAdi="",
                KullaniciSoyadi="",
                Kapandi=x.Kapandi,
                SiparisBilgileri=x.SiparisBilgileri.Where(y=>y.SiparisId==x.Id).ToList()
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Siparis, bool>> filter)
        {
            return BaseList(filter,x=> new SiparisL
            {
                Id=x.Id,
                Kod=x.Kod,
                CariId=x.CariId,
                CariAdi=x.Cari.CariAdi,
                CariAdres=x.Cari.Adres,
                KullaniciId=x.KullaniciId,
                KullaniciAdi="",
                KullaniciSoyadi="",
                SiparisTarihi=x.SiparisTarihi,
                TeslimTarihi=x.TeslimTarihi,
                Kapandi=x.Kapandi
            });
        }

    }
}
