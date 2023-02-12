using Willow.Infra.Data.Sql.Queries;
using Willow.Samples.Core.Contracts.People.Queries;
using Willow.Samples.Infra.Data.SqlQueries.Common;

namespace Willow.Samples.Infra.Data.SqlQueries.People
{
    public class PersonQueryRepository : BaseQueryRepository<SampleQueryDbContext>, IPersonQueryRepository
    {
        public PersonQueryRepository(SampleQueryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
