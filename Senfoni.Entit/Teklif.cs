using System;
using System.Collections.Generic;

namespace Senfoni.Entity
{
    public class Teklif:BaseEntity
    {
        public long CariId { get; set; }
        public string KullaniciId { get; set; }

        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public bool SipariseDonustu { get; set; }
        //public AspNetUsers Kullanici { get; set; }
        public Cari Cari { get; set; }

        public IEnumerable<TeklifBilgileri> TeklifBilgileri { get; set; }
        //public IEnumerable<Cari> CariList { get; set; }
    }
}
