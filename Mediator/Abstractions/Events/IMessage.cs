namespace Mediator.Abstractions.Events
{
    public interface IMessage : INotification
    {
        Guid MessageId { get; }
        DateTime Created { get; }
    }
}

