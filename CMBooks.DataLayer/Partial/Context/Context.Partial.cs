using Deventure.DataLayer.Interfaces;
using EntityFrameworkExtras.EF6;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CMBooks.DataLayer
{
    public partial class CMBooksEntities : IContext
    {
        private DbContextTransaction mTransactionContext;

        public void BeginTransaction()
        {
            mTransactionContext = Database.BeginTransaction();
        }

        public void CommitTransactionContext()
        {
            mTransactionContext.Commit();
        }

        public void DisposeTransactionContext()
        {
            mTransactionContext.Dispose();
            mTransactionContext = null;
        }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }

        public int GetState<T>(T item) where T : class
        {
            return (int)Entry(item).State;
        }

        public void SetAutoDetectChanges(bool enabled)
        {
            Configuration.AutoDetectChangesEnabled = enabled;
        }

        public void SetLazyLoadingEnabled(bool enabled)
        {
            Configuration.LazyLoadingEnabled = enabled;
        }

        public void SetState<T>(T item, int state) where T : class
        {
            Entry(item).State = (EntityState)state;
        }

        public void RollbackTransactionContext()
        {
            mTransactionContext.Rollback();
        }

        public bool IsTransactionContextInvalid()
        {
            if (mTransactionContext == null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<T> ExecuteStoredProcedure<T>(object storedProcedure)
        {
            throw new System.NotImplementedException();
        }
    }
}
