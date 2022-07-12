using Masa.Webaligner.Infrastructure.MessageBus.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Masa.Webaligner.Application.Services
{
    /// <summary>
    /// Serviço de polling no background para consumo de mensagens.
    /// </summary>
    public class AlignmentUpdateConsumer : BackgroundService
    {
        private readonly IMessageBusClient _client;

        /// <summary>
        /// Método construtor de AlignmentUpdateConsumer
        /// </summary>
        /// <param name="serviceProvider">Provedor de serviços.</param>
        public AlignmentUpdateConsumer(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                _client = scope.ServiceProvider
                    .GetRequiredService<IMessageBusClient>();
            }
        }

        /// <summary>
        /// Método para execução do serviço de polling de mensagens.
        /// </summary>
        /// <param name="stoppingToken">Token para cancelamento da execução.</param>
        /// <returns>Não há retorno.</returns>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
            // Task.Delay(500);
            // return Task.CompletedTask;
        }
    }
}
