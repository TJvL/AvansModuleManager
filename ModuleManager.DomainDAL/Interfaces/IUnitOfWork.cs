using System;

namespace ModuleManager.DomainDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DomainContext Context { get; }
    }
}
