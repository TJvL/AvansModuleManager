using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.DomainDAL.Utility;

namespace ModuleManager.DomainDAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DomainContext _context;

        public GenericRepository(DomainContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetOne(object[] keys)
        {
            return _context.Set<T>().Find(keys);
        }

        public string Create(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Added;
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    return DomainConstants.DbErrorPkDuplicate;
                if (ex is DbEntityValidationException)
                    return DomainConstants.DbErrorNoSelection;

                return DomainConstants.DbErrorStandard;
            }
            return "succes";
        }

        public string Delete(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    return DomainConstants.DbErrorFkConstraint;
                if (ex is ArgumentOutOfRangeException)
                    return DomainConstants.DbErrorPkInvalid;

                return DomainConstants.DbErrorStandard;
            }
            return "succes";
        }

        public string Edit(T entity)
        {
            try
            {
                //var dbEntityEntry = _context.Entry(entity);
                //foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                //{
                //    var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                //    var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                //    if (original != null && !original.Equals(current))
                //        dbEntityEntry.Property(property).IsModified = true;
                //}
                var test = _context.Entry(entity);
            }
            catch (Exception ex)
            {
                if (ex is DbUpdateException)
                    return DomainConstants.DbErrorFkConstraint;
                if (ex is InvalidOperationException)
                    return DomainConstants.DbErrorPkChanged;
                if (ex is ArgumentOutOfRangeException)
                    return DomainConstants.DbErrorPkInvalid;

                return DomainConstants.DbErrorStandard;
            }
            return "succes";
        }
    }
}
