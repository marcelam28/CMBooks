using System;
using LoggingService;
using System.Collections.Generic;
using Deventure.DataLayer.Interfaces;

namespace Deventure.DataLayer.Repositories
{
    public abstract class BaseDataRepository : IDisposable
    {
        #region private methods

        private const string CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE = "Tried to use repository with null context";
        private IContext mContext;

        #endregion

        public abstract bool IsEntityTrackingOn { get; set; }

        public virtual IContext Context
        {
            get { return mContext; }
            set
            {
                if (value == null)
                {
                    LogHelper.LogException<BaseDataRepository>(CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE);
                    throw new NullReferenceException(CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE);
                }
                value.SetLazyLoadingEnabled(false);
                mContext = value;
            }
        }

        public IEnumerable<T> ExecuteStoredProcedureList<T>(object storedProcedure)
        {
            return mContext.ExecuteStoredProcedure<T>(storedProcedure);
        }

        public void ExecuteStoredProcedure(object storedProcedure)
        {
            ExecuteStoredProcedure(storedProcedure);
        }

        #region Disposing logic

        public void Dispose()
        {
            Context.Dispose();
        }

        #endregion
    }
}