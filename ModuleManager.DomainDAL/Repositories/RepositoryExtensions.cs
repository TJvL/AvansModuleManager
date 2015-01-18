using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace ModuleManager.DomainDAL.Repositories
{
    public static class RepositoryExtensions
    {
        /// <summary>
        ///     Deze methode zorgt ervoor dat alle properties die in 'include' staan, geladen worden
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="query">DbContext.DbSet</param>
        /// <param name="includes">array van properties die geladen moeten worden</param>
        /// <returns>Dezelfde IQueryable die is meegegeven.</returns>
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

        /// <summary>
        ///     Verkrijg alle navigatieproperties van Type dat is meegegeven.
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <returns>Een array van alle navigatieproperties van Type</returns>
        public static string[] GetNavigationPropertiesTypeOfClass<T>()
            where T : class
        {
            List<string> propertyList = new List<string>();
            propertyList.AddRange(typeof(T).GetProperties()
                .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string)) || p.PropertyType.Namespace == typeof(T).Namespace)
                .Select(prop => prop.Name));
            return propertyList.ToArray();
        }

        /// <summary>
        ///     Verkrijg Reference navigatieproperties van Type dat is meegegeven.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Een array van alle Reference navigatieproperties van Type</returns>
        public static string[] GetReferenceNavigationPropertiesTypeOfClass<T>()
            where T : class
        {
            List<string> propertyList = new List<string>();
            propertyList.AddRange(typeof(T).GetProperties()
                .Where(p => p.PropertyType.Namespace == typeof(T).Namespace)
                .Select(prop => prop.Name));
            return propertyList.ToArray();
        }

        /// <summary>
        ///     Verkrijg Reference navigatieproperties van parameter dat is meegegeven.
        /// </summary>
        /// <param name="type">type in string-vorm</param>
        /// <returns>Een array van alle Reference navigatieproperties van Type</returns>
        public static string[] GetReferenceNavigationPropertiesTypeOfClass(string type)
        {
            var unnumberedType = Regex.Replace(type, @"[\d-]", string.Empty);
            var typename = "ModuleManager.DomainDAL." + unnumberedType + ", ModuleManager.DomainDAL";
            var T = Type.GetType(typename);
            List<string> propertyList = new List<string>();
            propertyList.AddRange(T.GetProperties()
                .Where(p => p.PropertyType.Namespace == T.Namespace)
                .Select(prop => prop.Name));
            return propertyList.ToArray();
        }

        /// <summary>
        ///     Verkrijg Collection navigatieproperties van Type dat is meegegeven.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Een array van alle Collection navigatieproperties van Type</returns>
        public static string[] GetCollectionNavigationPropertiesTypeOfClass<T>()
            where T : class
        {
            List<string> propertyList = new List<string>();
            propertyList.AddRange(typeof(T).GetProperties()
                .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string)))
                .Select(prop => prop.Name));
            return propertyList.ToArray();
        }

        /// <summary>
        ///     Verkrijg Collection navigatieproperties van Type dat is meegegeven.
        /// </summary>
        /// <param name="type">type in string-vorm</param>
        /// <returns>Een array van alle Collection navigatieproperties van Type</returns>
        public static string[] GetCollectionNavigationPropertiesTypeOfClass(string type)
        {
            var unnumberedType = Regex.Replace(type, @"[\d-]", string.Empty);
            var typename = "ModuleManager.DomainDAL." + unnumberedType + ", ModuleManager.DomainDAL";
            var T = Type.GetType(typename);
            List<string> propertyList = new List<string>();
            propertyList.AddRange(T.GetProperties()
                .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string)))
                .Select(prop => prop.Name));
            return propertyList.ToArray();
        }
    }
}
