namespace Mediator.Abstractions.Events
{
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
   where TEvent : INotification
    {
    }




   
}

