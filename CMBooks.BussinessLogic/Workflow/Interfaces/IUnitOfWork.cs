using Deventure.DataLayer.Repositories;
using System;

namespace CMBooks.BusinessLogic.Workflow.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        T TrackingRepository<T>() where T : BaseDataRepository, new();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
