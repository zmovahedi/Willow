using Willow.Infra.Data.Sql.Commands;
using Willow.Samples.Core.Contracts.People.Commands;
using Willow.Samples.Core.Domain.People.Entities;
using Willow.Samples.Infra.Data.SqlCommands.Common;

namespace Willow.Samples.Infra.Data.SqlCommands.People
{
    public class PersonCommandRepository : BaseCommandRepository<Person, SampleCommandDbContext>, IPersonCommandRepository
    {
        public PersonCommandRepository(SampleCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
