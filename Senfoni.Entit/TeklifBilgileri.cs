using Senfoni.Entity.Base;
using System;

namespace Senfoni.Entity
{
    public class TeklifBilgileri:BaseHareketEntity
    {
        public string KullaniciId { get; set; }
        public long TeklifId { get; set; }
        public long StokId { get; set; }
        public decimal TalepMiktari { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public bool SipariseDonustumu { get; set; }
        public long CariId { get; set; }
        public Stok Stok { get; set; }
        public Teklif Teklif { get; set; }
        //public AspNetUsers Kullanici { get; set; }
    }
}
