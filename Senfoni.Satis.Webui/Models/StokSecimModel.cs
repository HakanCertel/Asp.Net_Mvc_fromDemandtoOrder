using Senfoni.Entity.Dto;
using System.Collections.Generic;

namespace Senfoni.Satis.Webui.Models
{
    public class StokSecimModel
    {
        public IEnumerable<StokL> ListelenecekKayitlar { get; set; }
        public bool KayitUpdate { get; set; }
        public bool KayitInsert{ get; set; }
    }
}
