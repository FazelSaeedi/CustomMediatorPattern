using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mediator.Abstractions;

namespace customMediator
{


    public class testCommand : IRequest<int>
    {
        public testCommand(int message)
        {
            Message = message;
        }

        public int Message {get ; set;}
    }

    public class testCommandHandler : IRequestHandler<testCommand, int>
    {
        public testCommandHandler()
        {
        }

        public async Task<int> Handle(testCommand request)
        {
            return request.Message;
        }
        
    }

    public class testCommand2 : IRequest<int>
    {
        public testCommand2(int message)
        {
            Message = message;
        }

        public int Message {get ; set;}
    }

    public class testCommandHandler2 : IRequestHandler<testCommand, int>
    {
        public testCommandHandler2()
        {
        }

        public async Task<int> Handle(testCommand request)
        {
            return request.Message;
        }
        
    }


    public class testNotif : INotification<int>
    {
        public int num1 { get; set; }
        public testNotif(int num1)
        {
            this.num1 = num1;
        }
    }
 
    public class testNotifHandler : INotificationHandler<testNotif>
    {
        public testNotifHandler()
        {
        }

        public Task Handle(testNotif request)
        {
            long i = 0 ;
            while(i < 10000 )
            {
                Console.WriteLine(i + " testNotificationHandler1 ");
                i++;
            }
            return Task.CompletedTask;
        }
    }

 
    public class testNotifHandler1 : INotificationHandler<testNotif>
    {
        public testNotifHandler1()
        {
        }

        public Task Handle(testNotif request)
        {
            long i = 0 ;
            while(i < 10000 )
            {
                Console.WriteLine(i + " testNotificationHandler2 ");
                i++;
            }

            return Task.CompletedTask;
        }
    }
}