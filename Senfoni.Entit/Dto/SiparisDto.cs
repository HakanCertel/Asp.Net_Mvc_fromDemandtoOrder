using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senfoni.Entity.Dto
{
    [NotMapped]
    public class SiparisS:Siparis
    {
        public string CariAdi { get; set; }
        public string CariFax { get; set; }
        public string CariTelefon { get; set; }
        public string CariAdres { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSoyadi { get; set; }
    }
    public class SiparisL : BaseEntity
    {
        public long CariId { get; set; }
        public string KullaniciId { get; set; }
        public string CariAdi { get; set; }
        public string CariFax { get; set; }
        public string CariTelefon { get; set; }
        public string CariAdres { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSoyadi { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public bool Kapandi { get; set; }
    }
}
