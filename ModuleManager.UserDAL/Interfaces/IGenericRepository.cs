using System.Collections.Generic;

namespace ModuleManager.UserDAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(string key);
        bool Create(T entity);
        bool Delete(T entity);
        bool Edit(T entity);
    }
}