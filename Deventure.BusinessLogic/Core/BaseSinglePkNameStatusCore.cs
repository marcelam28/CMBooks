using Deventure.BusinessLogic.TypeManagement;
using Deventure.BusinessLogic.Workflow;
using Deventure.Common.Interfaces;
using Deventure.DataLayer.Interfaces;
using Deventure.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deventure.BusinessLogic.Core
{
    public class BaseSinglePkNameStatusCore<TRepo, TModel, TDataAccessModel> : BaseSinglePkCore<TRepo, TModel, TDataAccessModel>
        where TRepo : BaseSinglePkNameStatusRepository<TDataAccessModel>, new()
        where TDataAccessModel : class, IDataAccessObjectWithNameStatus, new()
        where TModel : class, ISinglePkModel, new()
    {
        public static async Task<IList<T>> HandleListAsync<T>(BaseSinglePkNameStatusRepository<T> repository, IList<string> namesCollection, Func<T, bool> prepareFunc = null)
            where T : class, IDataAccessObjectWithNameStatus, new()
        {
            var resultList = new List<T>();

            var existingEntities = await repository.GetListByNames(new List<string>(namesCollection)).ConfigureAwait(false);
            resultList.AddRange(existingEntities);

            var diff = namesCollection.Where(name => existingEntities.All(entity => entity.Name.ToLower() != name.ToLower())).ToList();
            if (diff.Count == 0)
            {
                return resultList;
            }

            var newEntities = diff.Select(name => new T
            {
                Name = name
            }).ToList();

            if (prepareFunc != null)
            {
                var finalList = new List<T>();
                foreach (var entity in newEntities)
                {
                    if (prepareFunc(entity))
                    {
                        finalList.Add(entity);
                    }
                }

                newEntities = finalList;
            }

            var createdEntities = await repository.CreateAsync(newEntities).ConfigureAwait(false);
            resultList.AddRange(createdEntities);

            return resultList;
        }

        public static async Task<IList<TModel>> GetAllAsync(IList<string> navigationProperties = null, Func<TDataAccessModel, string> orderByExpression = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAllAsync(navigationProperties).ConfigureAwait(false);
                if (orderByExpression == null)
                {
                    orderByExpression = entity => entity.Name;
                }
                return entities.OrderBy(orderByExpression).CopyTo<TModel>();
            }
        }
    }
}
