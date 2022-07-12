using Azure.Messaging.ServiceBus;
using Masa.Webaligner.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Masa.Webaligner.Infrastructure.MessageBus.Implementations
{
    public class AzureServiceBusClient : IMessageBusClient
    {
        private readonly ServiceBusClient _serviceBusClient;

        public AzureServiceBusClient(IOptions<InfrastructureOptions> options)
        {
            var messageBusOptions = options.Value.MessageBus;

            _serviceBusClient = new ServiceBusClient(
                messageBusOptions.ConnectionString
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
