using Masa.Webaligner.Infrastructure.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Masa.Webaligner.Infrastructure.MessageBus.Implementations
{
    public class RabbitMQClient : IMessageBusClient
    {
        private readonly IConnection _connection;

        public RabbitMQClient(IOptions<InfrastructureOptions> options)
        {
            var messageBusOptions = options.Value.MessageBus;

            var connectionFactory = new ConnectionFactory
            {
                HostName = messageBusOptions.HostName,
                UserName = messageBusOptions.UserName,
                Password = messageBusOptions.Password,
            };

            _connection = connectionFactory.CreateConnection(
                "masa-webaligner-client"
            );
        }

        public void Publish(object message, string queueName)
        {
            throw new NotImplementedException();
        }

        public void ReadMessage()
        {
            throw new NotImplementedException();
        }
    }
}
