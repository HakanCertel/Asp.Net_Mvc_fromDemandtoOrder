using Senfoni.Entity;
using System.Collections.Generic;
namespace Senfoni.Data.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        List<Category> GetPopularCategories ();
    }
}