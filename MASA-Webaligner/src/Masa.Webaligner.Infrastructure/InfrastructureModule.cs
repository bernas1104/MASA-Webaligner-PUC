using Masa.Webaligner.Core.Interfaces.Repositories;
using Masa.Webaligner.Core.Interfaces.UoW;
using Masa.Webaligner.Infrastructure.Context;
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
            bool IsDevelopment
        )
        {
            if (IsDevelopment)
            {
                services.AddDbContext<MasaContext>(
                    opt => opt.UseInMemoryDatabase("MasaDB")
                );
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAlignmentsRepository, AlignmentsRepository>();

            return services;
        }
    }
}
