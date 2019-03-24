using Deventure.Common.Interfaces;
using Deventure.DataLayer.Interfaces;
using System.Collections.Generic;

namespace CMBooks.BusinessLogic.Workflow.Interfaces
{

    public interface IMapperService
    {
        TDestType CopyTo<TDestType>(IModel entity) where TDestType : class;

        void CopyTo<TDestType>(IModel entity, TDestType destination) where TDestType : class;

        IList<TDestType> CopyTo<TDestType>(IEnumerable<IModel> entityList) where TDestType : class;

        TDestType CopyTo<TDestType>(IDataAccessObject entity) where TDestType : class;

        void CopyTo<TDestType>(IDataAccessObject entity, TDestType destination) where TDestType : class;

        IList<TDestType> CopyTo<TDestType>(IEnumerable<IDataAccessObject> entityList) where TDestType : class;
    }
}
