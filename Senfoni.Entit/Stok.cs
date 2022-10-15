using System.Collections.Generic;

namespace Senfoni.Entity
{
    public class Stok:BaseEntity
    {
        public string StokAdi { get; set; }
        public bool Durum { get; set; }
        public decimal Fiyat { get; set; }
        public string FiyatBirim { get; set; }
        public decimal StokMiktari { get; set; }
        public string Birim { get; set; }

        public ICollection<SiparisBilgileri> SiparisBilgileri { get; set; }
        public ICollection<TeklifBilgileri> TeklifBilgileri { get; set; }
    }
}
