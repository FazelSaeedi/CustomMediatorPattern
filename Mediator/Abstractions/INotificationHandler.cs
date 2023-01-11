using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator.Abstractions
{

    public interface INotificationHandler
    {

    }
    public interface INotificationHandler<in TRequest> : INotificationHandler where TRequest : INotification
    {

        Task Handle(TRequest request);
    }

}