using System.Collections.Generic;

namespace ModuleManager.DomainDAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(object[] keys);
        bool Create(T entity);
        bool Delete(T entity);
        bool Edit(T entity);
    }
}