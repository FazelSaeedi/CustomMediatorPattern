namespace Mediator.Abstractions.Events
{
    public interface IIntegrationEventMapper
    {
        IReadOnlyList<IIntegrationEvent?>? MapToIntegrationEvents(IReadOnlyList<IDomainEvent> domainEvents);
        IIntegrationEvent? MapToIntegrationEvent(IDomainEvent domainEvent);
    }
}

