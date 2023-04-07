using System.Net;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using gRPC_HTTP3_Client;
// create a httpHandler
var httpHandler = new HttpClientHandler();
//ignore certificate validations
httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
var httpClient = new HttpClient(httpHandler);
//httpClient.DefaultRequestVersion = HttpVersion.Version30;
//httpClient.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;


// The port number must match the port of the gRPC server.Pass the httpClient while creating gRPC connection
using var channel = GrpcChannel.ForAddress("https://localhost:5002", new GrpcChannelOptions { HttpClient = httpClient });
var client = new Message.MessageClient(channel);
// send 10 messages to the server
for (int i = 0;i < 10; i++)
{
    var message = new RequestMessage { Data = "unnie", SendTime = DateTime.UtcNow.ToTimestamp() };
    var reply = await client.SendAsync(message);
    Console.WriteLine("Replied received at:" + reply.ReceivedTime);
}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();