using Deventure.BusinessLogic.Pagination;
using Deventure.Common.Interfaces;
using Deventure.BusinessLogic.TypeManagement;
using Deventure.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deventure.BusinessLogic.Extensions
{
    public static class QueryableExtensions
    {
        public static T[] Paginate<T>(this IQueryable<T> query,int page, int takeCount)
            where T : class, new()
        {
           return query.Skip(page * takeCount).Take(takeCount).ToArray();
        }

        public static T[] Paginate<T>(this IQueryable<IDataAccessObject> dbQuery, BasePaginationModel paginationModel)
            where T : class, IModel
        {
            var data = dbQuery
                .Skip(paginationModel.Page * paginationModel.TakeCount)
                .Take(paginationModel.TakeCount)
                .ToArray();

            return data.CopyTo<T>().ToArray();
        }

    }
}
