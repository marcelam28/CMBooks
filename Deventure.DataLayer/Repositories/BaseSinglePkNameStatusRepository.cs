using Deventure.DataLayer.EF.Enums;
using Deventure.DataLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deventure.DataLayer.Repositories
{
    public class BaseSinglePkNameStatusRepository<T> : BaseSinglePkRepository<T> where T : class, IDataAccessObjectWithNameStatus, new()
    {
        public async Task<IList<T>> GetListByNames(IList<string> names)
        {
            for (var i = 0; i < names.Count; i++)
            {
                names[i] = names[i];
            }
            return await GetListAsync(entity => (names.Contains(entity.Name) && entity.Status == EntityStatus.Active)).ConfigureAwait(false);
        }

        public async Task<T> GetSingleByNameAsync(string name)
        {
            return await GetSingleAsync(entity => (entity.Name == name && entity.Status == EntityStatus.Active)).ConfigureAwait(false);
        }
    }
}
