using System.Collections.Generic;

namespace Senfoni.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        //public string Description { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
    }
}