using Deventure.BusinessLogic.Workflow;
using Deventure.DataLayer.Interfaces;
using Deventure.DataLayer.Repositories;
using UpWorky.BusinessLogic.Workflow.Interfaces;

namespace Deventure.BusinessLogic.Services
{
    public class RepoService : IRepoService
    {
        public TRepo CreateRepository<TRepo, TDataAccessModel>() where TRepo : BaseRepository<TDataAccessModel>, new()
                                                       where TDataAccessModel : class, IDataAccessObject, new()
        {
            return RepoUnitOfWork.CreateRepository<TRepo>();
        }

        public TRepo CreateTrackingRepository<TRepo, TDataAccessModel>()
                                                    where TRepo : BaseRepository<TDataAccessModel>, new()
                                                    where TDataAccessModel : class, IDataAccessObject, new()
        {
            return RepoUnitOfWork.CreateTrackingRepository<TRepo>();
        }
    }
}
