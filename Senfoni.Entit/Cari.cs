using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senfoni.Entity
{
    [NotMapped]
    public class Cari:BaseEntity
    {
        [Required, StringLength(50)]
        public string CariAdi { get; set; }

        [StringLength(14)]
        public string TcKimlikNo { get; set; }

        [StringLength(17)]
        public string Telefon1 { get; set; }

        [StringLength(17)]
        public string Telefon2 { get; set; }

        [StringLength(17)]
        public string Telefon3 { get; set; }

        [StringLength(17)]
        public string Telefon4 { get; set; }

        [StringLength(17)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Web { get; set; }

        [StringLength(50)]
        public string EMail { get; set; }

        [StringLength(50)]
        public string VergiDairesi { get; set; }

        [StringLength(20)]
        public string VergiNo { get; set; }

        [StringLength(155)]
        public string Adres { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public bool Durum { get; set; }

    }
}
