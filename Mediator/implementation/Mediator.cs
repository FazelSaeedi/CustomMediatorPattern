using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mediator.Mediator.Abstractions;

namespace mediator.Mediator.implementation
{

    public class Mediator : IMediator
    {
        public Dictionary<Type , Type > storage = new Dictionary<Type,Type>();

        public IMediator Bind<TIRequest , TIRequestHandler>() where TIRequest : IRequest where TIRequestHandler : IRequestHandler
        {
            storage.Add(typeof(TIRequest), typeof(TIRequestHandler));
            return this ;
        }


        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {

            var requestType = request.GetType();
            var handlerType =  storage.GetValueOrDefault(requestType)??throw new Exception("No Binding Exist");   

            var instance = Activator.CreateInstance(handlerType);

            object[] parameters = new object[] { request };
            var response = instance.GetType().GetMethod("Handle").Invoke(instance , parameters);
            var tResponse = await (Task<TResponse>)Convert.ChangeType(response, typeof(Task<TResponse>));
            return tResponse;
        }

 
    }

}