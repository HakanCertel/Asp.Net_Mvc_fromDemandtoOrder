using Senfoni.Entity.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senfoni.Entity.Dto
{
    [NotMapped]
    public class TeklifBilgileriL:TeklifBilgileri,IBaseHareketEntity
    {
        public string TeklifKodu { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string FiyatBirim { get; set; }
        public decimal Fiyat { get; set; }
        public string CariAdi { get; set; }
        public string CariFax { get; set; }
        public string CariTelefon { get; set; }
        public string CariAdres { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSoyadi { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
}
