using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpWorky.DataLayer
{
    public class CustomDBConfiguration : DbConfiguration
    {
        public CustomDBConfiguration()
        {
            SetExecutionStrategy(
                "System.Data.SqlClient",
                () => new SqlAzureExecutionStrategy(2, TimeSpan.FromSeconds(1)));
        }
    }
}
