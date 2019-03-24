using CMBooks.DataLayer.Services;
using Deventure.DataLayer.Interfaces;
using Deventure.DataLayer.Repositories;
using Deventure.DataLayer.Services;
using LoggingService;
using System;
using UpWorky.BusinessLogic.Workflow.Interfaces;

namespace Deventure.BusinessLogic.Workflow
{
    public class RepoUnitOfWork : IUnitOfWork
    {
        #region private fields 

        private const string ERROR_MESSAGE_TRANSACTION_NOT_FINALIZED = "The transaction was not finalized by the user";

        private IContext mContext;
        private bool mIsTransactionFinalized;
        private static IContextService mContextService = new ContextService();

        private readonly Type mScope;

        #endregion

        private RepoUnitOfWork()
        {
            InitializeUnitOfWork();
        }

        private RepoUnitOfWork(Type scope) : this()
        {
            mScope = scope;
        }

        public static T CreateRepository<T>() where T : BaseDataRepository, new()
        {
            var repository = new T
            {
                IsEntityTrackingOn = false,
            };
            repository.Context = mContextService.NewContext();
            return repository;
        }

        public static T CreateTrackingRepository<T>() where T : BaseDataRepository, new()
        {
            var repository = new T
            {
                IsEntityTrackingOn = true
            };
            repository.Context = mContextService.NewContext();
            return repository;
        }

        #region Factory logic

        /// <summary>
        /// Instantiate an object of type RepoUnitOfWork without a scope for logging purposes.
        /// This UnitOfWork will track object changes.
        /// </summary>
        /// <returns>An instance of the RepoUnitOfWork class</returns>
        public static RepoUnitOfWork New() => new RepoUnitOfWork();

        /// <summary>
        /// Instantiate an object of type RepoUnitOfWork using a scope for logging purposes.
        /// This UnitOfWork will track object changes.
        /// </summary>
        /// <returns>An instance of the RepoUnitOfWork class</returns>
        public static RepoUnitOfWork New<T>() where T : class => new RepoUnitOfWork(typeof(T));

        #endregion

        #region Disposing Logic

        public void Dispose()
        {
            if (mContext.IsTransactionContextInvalid())
            {
                mContext.DisposeTransactionContext();

                if (!mIsTransactionFinalized)
                {
                    if (mScope != null)
                    {
                        LogHelper.LogInfo(mScope, ERROR_MESSAGE_TRANSACTION_NOT_FINALIZED);
                    }
                    else
                    {
                        LogHelper.LogInfo<RepoUnitOfWork>(ERROR_MESSAGE_TRANSACTION_NOT_FINALIZED);
                    }
                }
            }

            if (mContext != null)
            {
                mContext.Dispose();
                mContext = null;
            }
        }

        #endregion

        #region Tracking Repo Factory logic

        public T TrackingRepository<T>() where T : BaseDataRepository, new()
        {

            var repository = new T
            {
                Context = mContext,
                IsEntityTrackingOn = true
            };

            return repository;
        }

        #endregion

        #region Non-Tracking Repo Factory logic

        public T Repository<T>() where T : BaseDataRepository, new()
        {
            return new T
            {
                Context = mContext,
            };

        }

        #endregion

        #region Transactions logic

        public void CommitTransaction()
        {
            if (mContext.IsTransactionContextInvalid())
            {
                throw new NullReferenceException("An SQL transaction was not initialized to run the Commit action");
            }

            if (mIsTransactionFinalized)
            {
                throw new InvalidOperationException("Cannot commit a transaction that was already commited or aborted");
            }

            mIsTransactionFinalized = true;
            mContext.CommitTransactionContext();
        }

        public void RollbackTransaction()
        {
            if (mContext.IsTransactionContextInvalid())
            {
                throw new NullReferenceException("An SQL transaction was not initialized to run the Rollback action");
            }

            if (mIsTransactionFinalized)
            {
                throw new InvalidOperationException("Cannot rollback a transaction that was already commited or aborted");
            }

            mIsTransactionFinalized = true;
            mContext.RollbackTransactionContext();
        }

        #endregion

        #region Initialization

        private void InitializeUnitOfWork()
        {
            //TODO: solve this
            //mContext = new Entities();
            mContext = mContextService.NewContext();
            //mTransaction = mContext.Database.BeginTransaction();
            mContext.BeginTransaction();
        }

        #endregion
    }
}