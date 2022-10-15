using Senfoni.Entity;
using Senfoni.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Senfoni.Data.Concrete.EfCore
{
    public class StokBll:BaseGenelBll<Stok>
    {
        public override IEnumerable<BaseEntity> List(Expression<Func<Stok, bool>> filter)
        {
            return BaseList(filter,x=> new 
            {
                stok=x,
                SiparisMiktari=x.SiparisBilgileri.Where(y=>y.StokId==x.Id).Select(y=>y.TalepMiktari).Sum(),
                toplamTeklif=x.TeklifBilgileri.Where(y=>y.StokId==x.Id).Select(y=>y.TalepMiktari).Sum(),
            }).ToList().Select(y=> new StokL
            {
                Id=y.stok.Id,
                Kod=y.stok.Kod,
                StokAdi=y.stok.StokAdi,
                Birim=y.stok.Birim,
                StokMiktari=y.stok.StokMiktari,
                Fiyat=y.stok.Fiyat,
                FiyatBirim=y.stok.FiyatBirim,
                Durum=y.stok.Durum,
                SiparisMiktari=y.SiparisMiktari,
                TeklifMiktari=y.toplamTeklif,
                KullanilabilirMiktar=y.stok.StokMiktari-y.SiparisMiktari
            });
        }
    }
}
