using System.Collections.Generic;

namespace ModuleManager.DomainDAL.Interfaces
{
    public interface INewGenericRepository
    {
        IEnumerable<T> GetAll<T>() where T : class;
        T GetOne<T>(object[] keys) where T : class;
        void Create<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Edit<T>(T entity) where T : class;
        void SaveAndClose();
    }
}