using Willow.Infra.Data.Sql.Commands;
using Willow.Samples.Core.Contracts.Common;

namespace Willow.Samples.Infra.Data.SqlCommands.Common
{
    public class SampleUnitOfWork : BaseEntityFrameworkUnitOfWork<SampleCommandDbContext>, ISampleUnitOfWork
    {
        public SampleUnitOfWork(SampleCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
