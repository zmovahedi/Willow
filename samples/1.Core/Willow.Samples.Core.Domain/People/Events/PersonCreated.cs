using Willow.Core.Domain.Events;

namespace Willow.Samples.Core.Domain.People.Events
{
    public class PersonCreated : IDomainEvent
    {
        public Guid BusinessId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public PersonCreated(Guid businessId, string firstName, string lastName)
        {
            BusinessId = businessId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
