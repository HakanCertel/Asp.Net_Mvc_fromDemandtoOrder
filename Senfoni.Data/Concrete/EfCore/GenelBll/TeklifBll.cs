using Senfoni.Entity;
using Senfoni.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Senfoni.Data.Concrete.EfCore.GenelBll
{
    public class TeklifBll:BaseGenelBll<Teklif>
    {
        public TeklifBll():base("TK"){}
        public override BaseEntity Single(Expression<Func<Teklif, bool>> filtre)
        {
            return BaseSingle(filtre,x=>new TeklifS
            {
                Id=x.Id,
                Kod=x.Kod,
                CariId=x.CariId,
                CariAdi=x.Cari.CariAdi,
                CariTelefon=x.Cari.Telefon1,
                KullaniciId=x.KullaniciId,
                KullaniciAdi="",
                KullaniciSoyadi="",
                SiparisTarihi=x.SiparisTarihi,
                TeslimTarihi=x.TeslimTarihi,
                SipariseDonustu=x.SipariseDonustu,
                TeklifBilgileri=x.TeklifBilgileri.Where(y=>y.TeklifId==x.Id),
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<Teklif, bool>> filter)
        {
            return BaseList(filter,x=>new TeklifL
            {
                Id=x.Id,
                Kod=x.Kod,
                CariAdi=x.Cari.CariAdi,
                CariTelefon=x.Cari.Telefon1,
                KullaniciId=x.KullaniciId,
                KullaniciAdi="",
                KullaniciSoyadi="",
                SiparisTarihi=x.SiparisTarihi,
                TeslimTarihi=x.TeslimTarihi,
                SipariseDonustu=x.SipariseDonustu,
            });
        }
    }
}
