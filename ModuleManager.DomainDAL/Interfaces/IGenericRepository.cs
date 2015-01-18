using System.Collections.Generic;

namespace ModuleManager.DomainDAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(object[] keys);
        void Create(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}