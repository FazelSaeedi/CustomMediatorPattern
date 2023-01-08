using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mediator.Mediator.Abstractions
{
    public interface IRequestHandler
    {

    }
    public interface IRequestHandler<in TRequest, TResponse> : IRequestHandler where TRequest : IRequest<TResponse> 
    {

        Task<TResponse> Handle(TRequest request);
    }
}