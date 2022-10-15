using Senfoni.Entity.Base;
using System;

namespace Senfoni.Entity
{
    public class SiparisBilgileri:BaseHareketEntity
    {
        public long CariId { get; set; }
        public string KullaniciId { get; set; }
        public long SiparisId { get; set; }
        public long StokId { get; set; }
        public decimal TalepMiktari { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public bool Kapandi { get; set; }

        public Stok Stok { get; set; }
        public Siparis Siparis { get; set; }
        public Cari Cari { get; set; }
    }
}
