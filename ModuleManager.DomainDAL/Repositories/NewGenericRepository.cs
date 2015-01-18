using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography.Xml;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class NewGenericRepository : INewGenericRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewGenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Deze methode laad alle navigatieproperties op level 1
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>een IEnumerable van objecten</returns>
        public IEnumerable<T> GetAll<T>() where T : class
        {
            // IncludeMultiple zorgt ervoor dat alle navigatiepropreties geladen worden. Dit is maar één level diep
            return _unitOfWork.Context.Set<T>().IncludeMultiple(RepositoryExtensions.GetNavigationPropertiesTypeOfClass<T>()).ToList();
        }

        /// <summary>
        ///     Deze methode laad alle navigatieproperties op level 1
        ///     Deze methode laad van de collecties all reference navigatieproperties
        ///     Reference navigatieproperties zijn complexe objecten vb. Module, Fase etc.
        ///     Collectie navigatieproperties zijn collecties vb. ICollections etc.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="keys">primary keys in object-array</param>
        /// <returns>één object die overeenkomt met de primary keys</returns>
        public T GetOne<T>(object[] keys) where T : class
        {
            var entity = _unitOfWork.Context.Set<T>().Find(keys);
            foreach (var navProperty in RepositoryExtensions.GetCollectionNavigationPropertiesTypeOfClass<T>())
            {
                // Alle Collection navigatieproperties worden geladen. Dit is laag 1
                _unitOfWork.Context.Entry(entity).Collection(navProperty).Load();

                foreach (var refProperty in RepositoryExtensions.GetReferenceNavigationPropertiesTypeOfClass(navProperty))
                {
                    // Alle Reference navigatieproperties worden geladen dit is laag 2
                    _unitOfWork.Context.Entry(entity).Collection(navProperty).Query().Include(refProperty).Load();
                }

                foreach (var nav2Property in RepositoryExtensions.GetCollectionNavigationPropertiesTypeOfClass(navProperty))
                {
                    // Alle Collectie navigatieproperties worden geladen dit is laag 2
                    _unitOfWork.Context.Entry(entity).Collection(navProperty).Query().Include(nav2Property).Load();
                }
            }
            foreach (var refProperty in RepositoryExtensions.GetReferenceNavigationPropertiesTypeOfClass<T>())
            {
                // Alle Reference navigatieproperties worden geladen. Dit is laag 1
                _unitOfWork.Context.Entry(entity).Reference(refProperty).Load();
            }
            return entity;
        }

        public void Create<T>(T entity) where T : class
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Added;
        }

        public void Delete<T>(T entity) where T : class
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Edit<T>(T entity) where T : class
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }


        public void SaveAndClose()
        {
            _unitOfWork.Context.Dispose();
        }
    }
}