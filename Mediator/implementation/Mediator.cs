using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Mediator.Abstractions;

namespace Mediator.implementation
{

    public class Mediator : IMediator
    {

        private Dictionary<Type , Type > DirectStorage = new Dictionary<Type,Type>();
        private Dictionary<Type , List<Type> > BroadcastStorage = new();

        public IMediator Bind<TIRequest , TIRequestHandler>() where TIRequest : IRequest where TIRequestHandler : IRequestHandler
        {
            DirectStorage.Add(typeof(TIRequest), typeof(TIRequestHandler));
            return this ;
        }



        public async Task Publish<TResponse>(INotification<TResponse> request)
        {
               
                var Handlers = BroadcastStorage.FirstOrDefault(x => x.Key == request.GetType());
                
                if(Handlers.Key == null )
                    return ;
                
                List<Task<object>> tasks = new ();
                foreach (var handler in Handlers.Value)
                {
                    var instance = Activator.CreateInstance(handler);

                    object[] parameters = new object[] { request };
                    
                    tasks.Add(Task.Run(() =>  instance.GetType().GetMethod("Handle").Invoke(instance , parameters) ));
                    
                }
                
                await Task.WhenAll(tasks);


        }


       

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {

            var requestType = request.GetType();
            var handlerType =  DirectStorage.GetValueOrDefault(requestType)??throw new Exception("No Binding Exist");   

            var instance = Activator.CreateInstance(handlerType);

            object[] parameters = new object[] { request };
            var response = instance.GetType().GetMethod("Handle").Invoke(instance , parameters);
            var tResponse = await (Task<TResponse>)Convert.ChangeType(response, typeof(Task<TResponse>));
            return tResponse;
        }

        public IMediator Subscribe<TINotification, TNotificationHandler>()
            where TINotification : INotification
            where TNotificationHandler : INotificationHandler
        {
                var existNotif = BroadcastStorage.FirstOrDefault(x => x.Key == typeof(TINotification));

                if(existNotif.Key == null)
                    BroadcastStorage.Add(typeof(TINotification), new List<Type>(){typeof(TNotificationHandler)});
                else 
                    existNotif.Value.Add(typeof(TNotificationHandler));

                return this ;
        }
    }

}