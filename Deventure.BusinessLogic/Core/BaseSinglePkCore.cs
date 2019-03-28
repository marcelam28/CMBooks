using Deventure.BusinessLogic.TypeManagement;
using Deventure.BusinessLogic.Workflow;
using Deventure.Common.Interfaces;
using Deventure.DataLayer.Interfaces;
using Deventure.DataLayer.Repositories;
using CMBooks.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Deventure.BusinessLogic.Core
{
    public abstract class BaseSinglePkCore<TRepo, TModel, TDataAccessModel> : BaseCore<TRepo, TModel, TDataAccessModel>
        where TRepo : BaseSinglePkRepository<TDataAccessModel>, new()
        where TDataAccessModel : class, ISinglePkDataAccessObject, new()
        where TModel : class, ISinglePkModel, new()
    {
        public static async Task<TModel> GetAsync(Guid id, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAsync(id, navigationProperties).ConfigureAwait(false);
                return entities.CopyTo<TModel>();
            }
        }

        public static TModel Get(Guid id, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = repository.Get(id, navigationProperties);
                return entities.CopyTo<TModel>();
            }
        }

        public static TDataAccessModel GetSingle(Expression<Func<TDataAccessModel, bool>> where, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = repository.GetSingle(where, navigationProperties);
                return entities;
            }
        }

        //gets ENTITY FRAMEWORK OBJECT
        public static async Task<TDataAccessModel> GetEfAsync(Guid id, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAsync(id, navigationProperties).ConfigureAwait(false);
                return entities;
            }
        }

        public static TDataAccessModel GetEf(Guid id, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = repository.Get(id, navigationProperties);
                return entities;
            }
        }

        public static async Task<Response> DeleteAsync(Guid id)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var result = await repository.DeleteAsync(id).ConfigureAwait(false);

                return ResponseFactory.CreateResponse(result, result ? ResponseCode.Success : ResponseCode.ErrorAnErrorOccurred);
            }
        }

        public static void Delete(Guid id, TRepo repo = null)
        {
            if (repo == null)
            {
                repo = RepoUnitOfWork.CreateTrackingRepository<TRepo>();
            }
            repo.Delete(id);
        }

        public static Response<TDataAccessModel> RestoreState(TDataAccessModel entityFromDb, TDataAccessModel entityToRestore)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                entityToRestore = entityFromDb;

                var result = repository.Update(entityToRestore, true);

                return ResponseFactory.CreateResponse(result != null, result != null ? ResponseCode.Success : ResponseCode.ErrorAnErrorOccurred, result);
            }
        }

        public static async Task<IList<T>> HandleListAsync<T>(BaseSinglePkRepository<T> repository, IList<Guid> idCollection)
           where T : class, ISinglePkDataAccessObject, new()
        {
            var resultList = new List<T>();

            var existingEntities = await repository.GetListAsync(entity => idCollection.Any(id => id == entity.Id)).ConfigureAwait(false);
            resultList.AddRange(existingEntities);

            var diff = idCollection.Where(id => existingEntities.All(entity => entity.Id != id)).ToList();

            if (diff.Count == 0)
            {
                return resultList;
            }
            var newEntities = diff.Select(id => new T
            {
                Id = id
            }).ToList();

            var createdEntities = await repository.CreateAsync(newEntities).ConfigureAwait(false);
            resultList.AddRange(createdEntities);

            return resultList;
        }

        public static IList<T> HandleList<T>(BaseSinglePkRepository<T> repository, IList<Guid> idCollection, IList<string> navigationProperties = null)
              where T : class, ISinglePkDataAccessObject, new()
        {
            var resultList = new List<T>();

            var existingEntities = repository.GetList(entity => idCollection.Any(id => id == entity.Id), navigationProperties);
            resultList.AddRange(existingEntities);

            var diff = idCollection.Where(id => existingEntities.All(entity => entity.Id != id)).ToList();

            if (diff.Count == 0)
            {
                return resultList;
            }
            var newEntities = diff.Select(id => new T
            {
                Id = id
            }).ToList();

            var createdEntities = repository.Create(newEntities);
            resultList.AddRange(createdEntities);

            return resultList;
        }

        public static async Task<IList<T>> HandleListAsync<T>(BaseSinglePkRepository<T> repository, IList<Guid> idCollection,
            Func<T, bool> prepareFunc = null, IList<string> navigationProperties = null)
            where T : class, ISinglePkDataAccessObject, new()
        {
            var resultList = new List<T>();

            var existingEntities = await repository.GetListAsync(
                            entity => idCollection.Any(id => id == entity.Id), navigationProperties).ConfigureAwait(false);
            resultList.AddRange(existingEntities);

            var diff = idCollection.Where(id => existingEntities.All(entity => entity.Id != id)).ToList();
            if (diff.Count == 0)
            {
                return resultList;
            }
            var newEntities = diff.Select(id => new T
            {
                Id = id
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
    }
}