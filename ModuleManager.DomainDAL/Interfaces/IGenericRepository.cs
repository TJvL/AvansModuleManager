using System.Linq;

namespace ModuleManager.DomainDAL.UnitOfWork
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetOne(string key);
        bool Create(T entity);
        bool Delete(T entity);
        bool Edit(T entity);
    }
}