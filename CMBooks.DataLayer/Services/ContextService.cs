using Deventure.DataLayer.Interfaces;
using Deventure.DataLayer.Services;

namespace CMBooks.DataLayer.Services
{
    public class ContextService : IContextService
    {
        public IContext NewContext()
        {
            return new CMBooksEntities();
        }
    }
}
