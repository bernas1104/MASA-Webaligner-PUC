using Masa.Webaligner.Application.Services;
using Masa.Webaligner.Application.UseCases.CreateAlignment;
using Microsoft.Extensions.DependencyInjection;

namespace Masa.Webaligner.Application
{
    /// <summary>
    /// Classe responsável por implementar as injeções de dependencia da camada
    /// de "Application" da aplicação.
    /// </summary>
    public static class ApplicationModule
    {
        /// <summary>
        /// Adiciona os componentes da camada de aplicação ao conteiner de
        /// serviços.
        /// </summary>
        /// <param name="services">Coleção de serviços.</param>
        /// <returns>Retorna a coleção de serviços.</returns>
        public static IServiceCollection AddApplication(
            this IServiceCollection services
        )
        {
            services.AddHostedService<AlignmentUpdateConsumer>();
            services.AddScoped<ICreateNcbiAlignmentUseCase, CreateNcbiAlignmentUseCase>();

            return services;
        }
    }
}
