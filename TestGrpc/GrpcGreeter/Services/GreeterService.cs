using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<AddResponse> AddNumber(AddRequest request, ServerCallContext context)
        {
            var result = 0;
            foreach(var item in request.Message)
            {
                result += item;
            }
            return Task.FromResult(new AddResponse { Result = result });
        }
    }
}
