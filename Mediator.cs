using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using mediator.Mediator.Abstractions;

namespace mediator
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
        public testCommand2(string message)
        {
            Message = message;
        }

        public string Message {get ; set;}
    }

    public class testCommandHandler2 : IRequestHandler<testCommand2, int>
    {
        public testCommandHandler2()
        {
        }

        public Task<int> Handle(testCommand2 request)
        {
            var T = request.Message ;

            return Task.FromResult(23);
        }
        
    }

}