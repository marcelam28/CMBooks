using Deventure.DataLayer.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Deventure.DataLayer.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyNavigationProperties<T>(this IQueryable<T> dbQuery, IList<string> navigationProperties)
            where T : class, IDataAccessObject
        {
            if (navigationProperties != null)
            {
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));
            }

            return dbQuery;
        }

        public static T[] Paginate<T>(this IQueryable<T> query, int page, int takeCount)
            where T : class, new()
        {
            return query.Skip(page * takeCount).Take(takeCount).ToArray();
        }
    }
}
