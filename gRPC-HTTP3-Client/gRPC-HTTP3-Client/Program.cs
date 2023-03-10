using System.Net;
using System.Threading.Tasks;
using Grpc.Net.Client;
using gRPC_HTTP3_Client;
// create a httpHandler
var httpHandler = new HttpClientHandler();
//ignore certificate validations
httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
var httpClient = new HttpClient(httpHandler);
/* //Uncomment below code if you are using .NET 6.0
 httpClient.DefaultRequestVersion = HttpVersion.Version30;
httpClient.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;
*/

// The port number must match the port of the gRPC server.Pass the httpClient while creating gRPC connection
using var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpClient = httpClient });
var client = new Greeter.GreeterClient(channel);
// send 10 messages to the server
for (int i = 0;i < 10; i++)
{
    var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
    Console.WriteLine("Greeting: " + reply.Message);
}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();