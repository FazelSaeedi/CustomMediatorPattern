using System;
using System.Threading.Tasks;
using Mediator.Abstractions;

namespace customMediator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");


            IMediator mediator = new Mediator.implementation.Mediator();


            mediator
                .Bind<testCommand , testCommandHandler>()
                .Bind<testCommand2 , testCommandHandler2>();


            mediator
                .Subscribe<testNotif , testNotifHandler>()
                .Subscribe<testNotif , testNotifHandler1>();



            await mediator.Publish<int>(new testNotif(25));

           

        }
    }
}
