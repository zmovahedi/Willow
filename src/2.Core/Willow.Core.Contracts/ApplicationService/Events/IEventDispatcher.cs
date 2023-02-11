using Willow.Core.Domain.Events;

namespace Willow.Core.Contracts.ApplicationService.Events
{
    public interface IEventDispatcher
    {
        Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;
    }
}
