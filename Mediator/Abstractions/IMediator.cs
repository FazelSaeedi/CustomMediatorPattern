using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mediator.Mediator.Abstractions
{
    public interface IMediator
    {
        public IMediator Bind<TIRequest , TIRequestHandler>() where TIRequest : IRequest where TIRequestHandler : IRequestHandler ;
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request) ;

    }
}