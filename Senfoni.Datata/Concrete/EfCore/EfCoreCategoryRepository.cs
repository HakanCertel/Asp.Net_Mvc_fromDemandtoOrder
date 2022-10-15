using System;
using System.Collections.Generic;
using Senfoni.Data.Abstract;
using Senfoni.Entity;

namespace Senfoni.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, SenfoniContext>, ICategoryRepository
    {
        public List<Category> GetPopularCategories()
        {
            throw new NotImplementedException();
        }
    }
}