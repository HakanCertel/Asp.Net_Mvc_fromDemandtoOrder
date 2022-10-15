using System;
using System.Collections.Generic;
using System.Text;

namespace Senfoni.Entity.Interfaces
{
    public interface IBaseHareketEntity
    {
        bool Insert { get; set; }
        bool Update { get; set; }
        bool Delete { get; set; }
    }
}
