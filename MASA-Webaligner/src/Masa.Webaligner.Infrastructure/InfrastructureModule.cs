using Masa.Webaligner.Core.Interfaces.Repositories;
using Masa.Webaligner.Core.Interfaces.UoW;
using Masa.Webaligner.Infrastructure.Context;
using Masa.Webaligner.Infrastructure.MessageBus;
using Masa.Webaligner.Infrastructure.MessageBus.Implementations;
using Masa.Webaligner.Infrastructure.Options;
using Masa.Webaligner.Infrastructure.Repositories;
using Masa.Webaligner.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Masa.Webaligner.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            string databaseConnectionString,
            InfrastructureOptions options,
            bool IsDevelopment
        )
        {
            services.AddDbContext<MasaContext>(
                opt => opt.UseSqlServer(databaseConnectionString)
            );

            if (IsDevelopment)
            {
                services.AddScoped<IMessageBusClient, RabbitMQClient>();
            }

            if (!IsDevelopment)
            {
                services.AddScoped<IMessageBusClient, AzureServiceBusClient>();
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAlignmentsRepository, AlignmentsRepository>();

            services.AddScoped<IEventProcessor, EventProcessor>();

            return services;
        }
    }
}
