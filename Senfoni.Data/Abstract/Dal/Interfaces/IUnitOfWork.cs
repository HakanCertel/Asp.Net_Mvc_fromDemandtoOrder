using System;

namespace Senfoni.Data.Concrete.EfCore
{
    public interface IUnitOfWork<T>:IDisposable where T:class 
    {
        IRepositoryy<T> Rep { get; }

        bool Save();
    }
}
