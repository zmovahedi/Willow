using Microsoft.EntityFrameworkCore;
using Willow.Infra.Data.Sql.Queries;

namespace Willow.Samples.Infra.Data.SqlQueries.Common
{
    public class SampleQueryDbContext : BaseQueryDbContext
    {
        public SampleQueryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
