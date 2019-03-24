using Deventure.BusinessLogic.Extensions;
using Deventure.Common.Interfaces;
using Deventure.DataLayer.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Deventure.BusinessLogic.Pagination
{

    public abstract class BasePaginationModel
    {
        public BasePaginationModel(int takeCount = BasePaginationConstants.REGISTRATIONS_PER_PAGE)
        {
            Page = 0;
            TakeCount = takeCount;
        }

        public int TakeCount { get; set; }

        [Required]
        public int Page { get; set; }

        [Required]
        public int ActiveIndex { get; set; }

        public int OrderIndex { get; set; }

        public bool OrderDescending { get; set; }

        public abstract IQueryable<T> GetFilterQuery<T>(IQueryable<T> query)
            where T : class, IDataAccessObject, new();

        public abstract IQueryable<T> GetOrderQuery<T>(IQueryable<T> query)
            where T : class, IDataAccessObject, new();

        /// <summary>
        /// Used to validate ActiveIndex as value of an Enum Type
        /// </summary>
        /// <param name="enumType">typeof(EnumType)</param>
        /// <returns></returns>
        public bool IsActiveIndexValidOnEnum(Type enumType)
        {
            return Enum.IsDefined(enumType, ActiveIndex);
        }

        public int ProcessCount(int count)
        {
            var totalPages = (int)Math.Ceiling((float)count / (float)TakeCount);
            if (Page > totalPages)
            {
                Page = 0;
            }

            return totalPages;
        }

        public PaginationResult<T> BuildResult<T, U>(IQueryable<U> query)
            where T : class, IModel, new()
            where U : class, IDataAccessObject, new()
        {
            query = GetFilterQuery(query);
            if (query == null)
            {
                return new PaginationResult<T>()
                {
                    TotalPages = 0,
                    ActiveIndex = ActiveIndex,
                    CurrentPage = 0,
                    TotalElementsCount = 0
                };
            }

            var count = query.Count();
            var totalPages = ProcessCount(count);

            query = GetOrderQuery(query);
            if (query == null)
            {
                return new PaginationResult<T>()
                {
                    TotalPages = 0,
                    ActiveIndex = ActiveIndex,
                    CurrentPage = 0,
                    TotalElementsCount = 0
                };
            }

            return new PaginationResult<T>()
            {
                TotalPages = totalPages,
                ActiveIndex = ActiveIndex,
                CurrentPage = Page,
                TotalElementsCount = count,
                Data = query.Paginate<T>(this)
            };
        }

        protected IQueryable<U> BeginQuery<U>(IQueryable<IDataAccessObject> query)
            where U : class, IDataAccessObject, new()
        {
            return query.Cast<U>();
        }

        protected IQueryable<T> EndQuery<T>(IQueryable<IDataAccessObject> query)
           where T : class, IDataAccessObject, new()
        {
            return query.Cast<T>();
        }
    }
}
