using System;
using System.Collections.Generic;

namespace Senfoni.Entity
{
    public class Siparis:BaseEntity
    {
        public long CariId { get; set; }
        public string KullaniciId { get; set; }

        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public bool Kapandi { get; set; }

        public Cari Cari { get; set; }
        public ICollection<SiparisBilgileri> SiparisBilgileri { get; set; }
    }
}
