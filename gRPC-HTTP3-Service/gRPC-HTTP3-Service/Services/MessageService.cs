using Grpc.Core;
using gRPC_HTTP3_Service;

namespace gRPC_HTTP3_Service.Services
{
    public class MessageService : Message.MessageBase
    {
        private readonly ILogger<MessageService> _logger;
        public MessageService(ILogger<MessageService> logger)
        {
            _logger = logger;
        }

        public override Task<MessageReply> Send(RequestMessage request, ServerCallContext context)
        {
            return Task.FromResult(new MessageReply
            {
                Message = "Hello " + request.Message
            });
        }
    }
}