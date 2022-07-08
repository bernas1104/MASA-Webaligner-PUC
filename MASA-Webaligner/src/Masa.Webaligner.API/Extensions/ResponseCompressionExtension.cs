using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

namespace Masa.Webaligner.API.Extensions
{
    /// <summary>
    /// Responsável por configurar e adicionar os serviços de compressão de
    /// resposta da API.
    /// </summary>
    public static class ResponseCompressionExtension
    {
        /// <summary>
        /// Configura e injeta os serviços no container da API.
        /// </summary>
        /// <param name="services">Conteiner de serviços.</param>
        /// <returns>Conteiner de serviços atualizado.</returns>
        public static IServiceCollection AddResponseCompression(
            this IServiceCollection services
        )
        {
            services.Configure<BrotliCompressionProviderOptions>(
                x => x.Level = CompressionLevel.SmallestSize
            );
            services.Configure<GzipCompressionProviderOptions>(
                x => x.Level = CompressionLevel.SmallestSize
            );
            services.AddResponseCompression(
                x =>
                {
                    x.Providers.Add<BrotliCompressionProvider>();
                    x.Providers.Add<GzipCompressionProvider>();
                    x.EnableForHttps = true;
                }
            );

            return services;
        }
    }
}
