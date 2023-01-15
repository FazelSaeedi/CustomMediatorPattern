namespace Mediator.Abstractions.Events
{
    public interface IIDomainNotificationEventMapper
    {
        IReadOnlyList<IDomainNotificationEvent?>? MapToDomainNotificationEvents(IReadOnlyList<IDomainEvent> domainEvents);
        IDomainNotificationEvent? MapToDomainNotificationEvent(IDomainEvent domainEvent);
    }
}

