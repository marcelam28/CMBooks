using Deventure.BusinessLogic.Services;
using Deventure.BusinessLogic.Workflow;
using Deventure.Common.Interfaces;
using Deventure.Common.Response;
using Deventure.DataLayer.Interfaces;
using Deventure.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UpWorky.BusinessLogic.Workflow.Interfaces;
using Deventure.BusinessLogic.TypeManagement;

namespace Deventure.BusinessLogic.Core
{
    public abstract class BaseCore<TRepo, TModel, TDataAccessModel>
        where TRepo : BaseRepository<TDataAccessModel>, new()
        where TDataAccessModel : class, IDataAccessObject, new()
        where TModel : class, IModel, new()
    {

        protected static IRepoService mRepoService = new RepoService();
        //protected static IMapperService mRepoService = new RepoService();


        #region Singular structure result methods

        public static async Task<int> CountAsync()
        {
            using (var repository = mRepoService.CreateRepository<TRepo, TDataAccessModel>())
            {
                return await repository.CountAsync().ConfigureAwait(false);
            }
        }

        public static async Task<int> CountAsync(Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = mRepoService.CreateRepository<TRepo, TDataAccessModel>())
            {
                return await repository.CountAsync(@where).ConfigureAwait(false);
            }
        }

        public static int Count(Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = mRepoService.CreateRepository<TRepo, TDataAccessModel>())
            {
                return repository.Count(@where);
            }
        }

        #region Sum

        public async Task<int> SumAsync(Expression<Func<TDataAccessModel, int>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int?> SumAsync(Expression<Func<TDataAccessModel, int?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int> SumAsync(Expression<Func<TDataAccessModel, int>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<int?> SumAsync(Expression<Func<TDataAccessModel, int?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float> SumAsync(Expression<Func<TDataAccessModel, float>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float?> SumAsync(Expression<Func<TDataAccessModel, float?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float> SumAsync(Expression<Func<TDataAccessModel, float>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float?> SumAsync(Expression<Func<TDataAccessModel, float?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double> SumAsync(Expression<Func<TDataAccessModel, double>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double?> SumAsync(Expression<Func<TDataAccessModel, double?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double> SumAsync(Expression<Func<TDataAccessModel, double>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double?> SumAsync(Expression<Func<TDataAccessModel, double?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal> SumAsync(Expression<Func<TDataAccessModel, decimal>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> SumAsync(Expression<Func<TDataAccessModel, decimal?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal> SumAsync(Expression<Func<TDataAccessModel, decimal>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> SumAsync(Expression<Func<TDataAccessModel, decimal?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        #endregion

        #region Min

        public async Task<int> MinAsync(Expression<Func<TDataAccessModel, int>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int?> MinAsync(Expression<Func<TDataAccessModel, int?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int> MinAsync(Expression<Func<TDataAccessModel, int>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<int?> MinAsync(Expression<Func<TDataAccessModel, int?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float> MinAsync(Expression<Func<TDataAccessModel, float>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float?> MinAsync(Expression<Func<TDataAccessModel, float?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float> MinAsync(Expression<Func<TDataAccessModel, float>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float?> MinAsync(Expression<Func<TDataAccessModel, float?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double> MinAsync(Expression<Func<TDataAccessModel, double>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double?> MinAsync(Expression<Func<TDataAccessModel, double?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double> MinAsync(Expression<Func<TDataAccessModel, double>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double?> MinAsync(Expression<Func<TDataAccessModel, double?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal> MinAsync(Expression<Func<TDataAccessModel, decimal>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> MinAsync(Expression<Func<TDataAccessModel, decimal?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal> MinAsync(Expression<Func<TDataAccessModel, decimal>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> MinAsync(Expression<Func<TDataAccessModel, decimal?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        #endregion

        #region Max

        public async Task<int> MaxAsync(Expression<Func<TDataAccessModel, int>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int?> MaxAsync(Expression<Func<TDataAccessModel, int?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int> MaxAsync(Expression<Func<TDataAccessModel, int>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<int?> MaxAsync(Expression<Func<TDataAccessModel, int?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float> MaxAsync(Expression<Func<TDataAccessModel, float>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float?> MaxAsync(Expression<Func<TDataAccessModel, float?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float> MaxAsync(Expression<Func<TDataAccessModel, float>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float?> MaxAsync(Expression<Func<TDataAccessModel, float?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double> MaxAsync(Expression<Func<TDataAccessModel, double>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double?> MaxAsync(Expression<Func<TDataAccessModel, double?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double> MaxAsync(Expression<Func<TDataAccessModel, double>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double?> MaxAsync(Expression<Func<TDataAccessModel, double?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal> MaxAsync(Expression<Func<TDataAccessModel, decimal>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> MaxAsync(Expression<Func<TDataAccessModel, decimal?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal> MaxAsync(Expression<Func<TDataAccessModel, decimal>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> MaxAsync(Expression<Func<TDataAccessModel, decimal?>> selector, Expression<Func<TDataAccessModel, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        #endregion

        #endregion

        public static IEnumerable<TDataAccessModel> ExecuteStoredProcedureList(IStoreProcedure storedProcedure)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return repository.ExecuteStoredProcedureList<TDataAccessModel>(storedProcedure);
            }
        }

        public static void ExecuteStoredProcedure(IStoreProcedure storedProcedure)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                repository.ExecuteStoredProcedure(storedProcedure);
            }
        }

        #region CRUD

        public static async Task<IList<TModel>> GetAllAsync(IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAllAsync(navigationProperties).ConfigureAwait(false);
                return entities.CopyTo<TModel>();
            }
        }

        public static IList<TModel> GetAll(IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = repository.GetAll(navigationProperties);
                return entities.CopyTo<TModel>();
            }
        }

        public static IList<TDataAccessModel> GetAllEF(IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = repository.GetAll(navigationProperties);
                return entities;
            }
        }


        public static async Task<IList<TDataAccessModel>> GetAllEFAsync(IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAllAsync(navigationProperties).ConfigureAwait(false);
                return entities;
            }
        }

        public static async Task<IList<TModel>> GetAllAsync<TKey>(IList<string> navigationProperties = null, Func<TDataAccessModel, TKey> orderByExpression = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAllAsync(navigationProperties).ConfigureAwait(false);
                if (orderByExpression != null)
                {
                    return entities.OrderBy(orderByExpression).CopyTo<TModel>();
                }
                return entities.CopyTo<TModel>();
            }
        }

        public static IList<TModel> GetList(Expression<Func<TDataAccessModel, bool>> where, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = repository.GetList(@where, navigationProperties);
                return entities.CopyTo<TModel>();
            }
        }

        public static IList<TDataAccessModel> GetListEF(Expression<Func<TDataAccessModel, bool>> where, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = repository.GetList(@where, navigationProperties);
                return entities;
            }
        }

        public static async Task<IList<TModel>> GetListAsync(Expression<Func<TDataAccessModel, bool>> where, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetListAsync(@where, navigationProperties).ConfigureAwait(false);

                return entities.CopyTo<TModel>();
            }
        }

        public static async Task<IList<TDataAccessModel>> GetListEFAsync(Expression<Func<TDataAccessModel, bool>> where, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetListAsync(@where, navigationProperties).ConfigureAwait(false);

                return entities;
            }
        }
        public static async Task<TModel> CreateAsync(TModel model, bool refreshFromDb = false, TRepo Trepository = null, IList<string> navigationProperties = null)
        {
            if (Trepository == null)
            {
                Trepository = RepoUnitOfWork.CreateTrackingRepository<TRepo>();
            }
            var entity = model.CopyTo<TDataAccessModel>();

            entity = await Trepository.CreateAsync(entity, refreshFromDb, navigationProperties).ConfigureAwait(false);

            return entity.CopyTo<TModel>();

        }

        public static TDataAccessModel Create(TDataAccessModel model, bool refreshFromDb = false, TRepo Trepository = null, IList<string> navigationProperties = null)
        {
            if (Trepository == null)
            {
                Trepository = RepoUnitOfWork.CreateTrackingRepository<TRepo>();
            }

            model = Trepository.Create(model, refreshFromDb, navigationProperties);

            return model;
        }

        public static async Task<IList<TModel>> CreateAsync(IList<TModel> modelCollection, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entityCollection = modelCollection.CopyTo<TDataAccessModel>();

                entityCollection = await repository.CreateAsync(entityCollection, refreshFromDb, navigationProperties).ConfigureAwait(false);

                return entityCollection.CopyTo<TModel>();
            }
        }

        public static async Task<TModel> UpdateAsync(TModel model, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entity = model.CopyTo<TDataAccessModel>();

                entity = await repository.UpdateAsync(entity, refreshFromDb, navigationProperties).ConfigureAwait(false);

                return entity.CopyTo<TModel>();
            }
        }

        public static async Task<TModel> UpdateAsync(TDataAccessModel entity, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                entity = await repository.UpdateAsync(entity, refreshFromDb, navigationProperties).ConfigureAwait(false);

                return entity.CopyTo<TModel>();
            }
        }

        public static TModel Update(TDataAccessModel entity, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                entity = repository.Update(entity, refreshFromDb, navigationProperties);
                return entity.CopyTo<TModel>();
            }
        }

        public static TModel Update(TModel model, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entity = model.CopyTo<TDataAccessModel>();
                entity = repository.Update(entity, refreshFromDb, navigationProperties);
                return entity.CopyTo<TModel>();
            }
        }

        public static async Task<IList<TModel>> UpdateAsync(IList<TModel> modelCollection, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entityCollection = modelCollection.CopyTo<TDataAccessModel>();

                entityCollection = await repository.UpdateAsync(entityCollection, refreshFromDb, navigationProperties).ConfigureAwait(false);

                return entityCollection.CopyTo<TModel>();
            }
        }

        public static async Task<IList<TModel>> UpdateAsync(IList<TDataAccessModel> entityCollection, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                entityCollection = await repository.UpdateAsync(entityCollection, refreshFromDb, navigationProperties).ConfigureAwait(false);

                return entityCollection.CopyTo<TModel>();
            }
        }

        public static bool Delete(TDataAccessModel entity, TRepo repo = null)
        {
            if (repo == null)
            {
                repo = RepoUnitOfWork.CreateTrackingRepository<TRepo>();
            }

            return repo.Delete(entity);
        }


        public static async Task<bool> DeleteAsync(TModel model)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entity = model.CopyTo<TDataAccessModel>();

                return await repository.DeleteAsync(entity).ConfigureAwait(false);
            }
        }

        public static async Task<bool> DeleteAsync(TDataAccessModel model)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                return await repository.DeleteAsync(model).ConfigureAwait(false);
            }
        }

        public static async Task<bool> DeleteAsync(IList<TModel> modelCollection)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entityCollection = modelCollection.CopyTo<TDataAccessModel>();

                return await repository.DeleteAsync(entityCollection).ConfigureAwait(false);
            }
        }

        public static async Task<Response> DeleteAllAsync()
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entities = await repository.GetAllAsync().ConfigureAwait(false);

                await repository.DeleteAsync(entities).ConfigureAwait(false);

                entities = await repository.GetAllAsync().ConfigureAwait(false);
                if (entities != null && entities.Any())
                {
                    //TODO: Add a ResponseCode Enum
                    //return ResponseFactory.CreateResponse(false, ResponseCode.ErrorAnErrorOccurred);
                    return ResponseFactory.CreateResponse(true, -1);
                }

                //return ResponseFactory.CreateResponse(true, ResponseCode.Success);
                return ResponseFactory.CreateResponse(true, 0);

            }
        }

        #endregion
    }
}