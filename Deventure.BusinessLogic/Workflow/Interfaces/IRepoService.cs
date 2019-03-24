using Deventure.DataLayer.Interfaces;
using Deventure.DataLayer.Repositories;
using System;

namespace UpWorky.BusinessLogic.Workflow.Interfaces
{

    public interface IRepoService
    {
        TRepo CreateRepository<TRepo, TDataAccessModel>() where TRepo : BaseRepository<TDataAccessModel>, new()
                                                       where TDataAccessModel : class, IDataAccessObject, new();

        TRepo CreateTrackingRepository<TRepo, TDataAccessModel>()
                                                    where TRepo : BaseRepository<TDataAccessModel>, new()
                                                    where TDataAccessModel : class, IDataAccessObject, new();
    }
}
