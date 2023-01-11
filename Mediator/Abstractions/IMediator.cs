using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator.Abstractions
{
    public interface IMediator
    {
        public IMediator Bind<TIRequest , TIRequestHandler>() where TIRequest : IRequest where TIRequestHandler : IRequestHandler ;
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request) ;
        public Task Publish<TResponse>(INotification<TResponse> request) ;
        public IMediator Subscribe<TINotification , TNotificationHandler>() where TINotification : INotification where TNotificationHandler : INotificationHandler ;

    }
}