using System;
using System.Collections.Generic;
using System.Linq;
using Senfoni.Data.Abstract;
using Senfoni.Entity;

namespace Senfoni.Data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, SenfoniContext>, IProductRepository
    {
        public List<Product> GetPopularProducts()
        {
            using (var context=new SenfoniContext())
            {
                return context.Products.ToList();
            }
        }

        public List<Product> GetTop5Products()
        {
            throw new NotImplementedException();
        }
    }
}