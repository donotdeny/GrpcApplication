using Grpc.Net.Client;
using GrpcGreeterClient;
using Microsoft.AspNetCore.Mvc;

namespace TestGrpcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestAsync()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5097");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            return Ok(reply);
        }

        [HttpGet("add-range")]
        public async Task<IActionResult> TestAddRangeAsync()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5097");
            var client = new Greeter.GreeterClient(channel);
            var addRequest = new AddRequest();
            List<int> listNumber = [1, 2, 3];
            addRequest.Message.AddRange(listNumber);
            var reply = await client.AddNumberAsync(addRequest);
            return Ok(reply);
        }
    }
}
