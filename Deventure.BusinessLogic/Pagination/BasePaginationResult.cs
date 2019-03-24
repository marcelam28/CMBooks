using Deventure.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deventure.BusinessLogic.Pagination
{
    public class PaginationResult<T> : BaseEntityContainer
        where T : class,
        new()
    {
        public PaginationResult()
            : base()
        {
            Data = new T[0];
        }

        public PaginationResult(BasePaginationModel paginationModel)
            : base()
        {
            Data = new T[0];
            CurrentPage = paginationModel.Page;
            ActiveIndex = paginationModel.ActiveIndex;
        }

        public T[] Data { get; set; }

        public static PaginationResult<T> Empty()
        {
            return new PaginationResult<T>();
        }
    }
}
