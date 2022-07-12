namespace Masa.Webaligner.Infrastructure.MessageBus.Implementations
{
    public interface IMessageBusClient
    {
        void Publish(object message, string queueName);
        void ReadMessage();
    }
}
