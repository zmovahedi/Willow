using Willow.Core.Contracts.ApplicationService.Commands;

namespace Willow.Samples.Core.Contracts.People.Commands
{
    public class CreatePerson : ICommand<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
