using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Senfoni.Entity.Dto
{
    [NotMapped]
    public class TeklifS:Teklif
    {
        public string CariAdi{ get; set; }
        public string CariFax { get; set; }
        public string CariTelefon { get; set; }
        public string CariAdres { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSoyadi { get; set; }
    }
    public class TeklifL : BaseEntity
    {
        public long CariId { get; set; }
        public string KullaniciId { get; set; }
        public string CariAdi { get; set; }
        public string CariFax { get; set; }
        public string CariTelefon { get; set; }
        public string CariAdres { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSoyadi { get; set; }
        public bool SipariseDonustu { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
    }
}
