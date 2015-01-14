using System;
namespace ModuleManager.DomainDAL.Interfaces
{
    public interface IUnitOfWork
    {
        DomainContext Context { get; }
    }
}
