using System;
using System.Threading.Tasks;
using mediator.Mediator.Abstractions;

namespace mediator
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


            var obj1 =  await mediator.Send<int>(new testCommand(123));
            var obj2 =  await mediator.Send<int>(new testCommand(12345));
            var obj3 =  await mediator.Send<int>(new testCommand2("sdsd"));

        }
    }
}
