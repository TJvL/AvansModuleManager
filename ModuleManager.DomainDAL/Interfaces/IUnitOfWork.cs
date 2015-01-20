using System;

namespace ModuleManager.DomainDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DomainContext Context { get; }

        IGenericRepository<T> GetRepository<T>() where T : class;
        void SaveToDatabase();
    }
}