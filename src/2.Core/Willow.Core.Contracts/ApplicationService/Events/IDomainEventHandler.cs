using Willow.Core.Domain.Events;

namespace Willow.Core.Contracts.ApplicationService.Events
{
    public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        Task Handle(TDomainEvent Event);
    }
}
