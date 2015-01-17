using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.DomainDAL.Repositories
{
    public static class Test
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, string[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }

        public static string[] GetNavigationPropertiesNameOfClass<T>()
            where T : class
        {
            List<string> propertyList = new List<string>();
            propertyList.AddRange(typeof(T).GetProperties()
                .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string)) || p.PropertyType.Namespace == typeof(T).Namespace)
                .Select(prop => prop.Name));
            return propertyList.ToArray();
        }
    }
}
