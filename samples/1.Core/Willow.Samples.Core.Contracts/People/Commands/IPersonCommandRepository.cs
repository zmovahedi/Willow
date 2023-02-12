using Willow.Core.Contracts.Data.Commands;
using Willow.Samples.Core.Domain.People.Entities;

namespace Willow.Samples.Core.Contracts.People.Commands
{
    public interface IPersonCommandRepository : ICommandRepository<Person>
    {
    }
}
