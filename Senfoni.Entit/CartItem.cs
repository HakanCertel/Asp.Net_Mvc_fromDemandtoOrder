using System;
using System.Collections.Generic;
using System.Text;

namespace Senfoni.Entity
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public string KullaniciId { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
