using Senfoni.Entity;
using System.Collections.Generic;

namespace Senfoni.Data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        List<Product> GetPopularProducts ();

        List<Product> GetTop5Products();
    }
}