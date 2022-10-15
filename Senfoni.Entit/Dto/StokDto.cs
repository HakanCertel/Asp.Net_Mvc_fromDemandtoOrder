using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Senfoni.Entity.Dto
{
    [NotMapped]
    public class StokS:Stok
    {

    }
    public class StokL : BaseEntity
    {
        public string StokAdi { get; set; }
        public bool Durum { get; set; }
        public decimal Fiyat { get; set; }
        public string FiyatBirim { get; set; }
        public decimal StokMiktari { get; set; }
        public string Birim { get; set; }
        public decimal TeklifMiktari { get; set; }
        public decimal SiparisMiktari { get; set; }
        public decimal KullanilabilirMiktar { get; set; }   
    }
}
