using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().ToList();
        }

        public T GetOne(object[] keys)
        {
            return _unitOfWork.Context.Set<T>().Find(keys);
        }

        public void Create(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Edit(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public void SaveAndClose()
        {
            _unitOfWork.Dispose();
        }
    }
}