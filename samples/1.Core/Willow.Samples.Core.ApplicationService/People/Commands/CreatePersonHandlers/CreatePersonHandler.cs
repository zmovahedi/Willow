using Willow.Core.ApplicationService.Commands;
using Willow.Core.Contracts.ApplicationService.Commands;
using Willow.Samples.Core.Contracts.People.Commands;
using Willow.Samples.Core.Domain.People.Entities;
using Willow.Samples.Core.Domain.People.ValueObjects;
using Willow.Utilities;

namespace Willow.Samples.Core.ApplicationService.People.Commands.CreatePersonHandlers
{
    public class CreatePersonHandler : CommandHandler<CreatePerson, int>
    {
        private readonly IPersonCommandRepository _repository;

        public CreatePersonHandler(WillowService willowService, IPersonCommandRepository repository) : base(willowService)
        {
            _repository = repository;
        }

        public override async Task<CommandResult<int>> Handle(CreatePerson request)
        {
            Person person = new(new FirstName(request.FirstName), new LastName(request.LastName));
            await _repository.InsertAsync(person);
            await _repository.CommitAsync();
            return Ok(person.Id);
        }
    }
}
