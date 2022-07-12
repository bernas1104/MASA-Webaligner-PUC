#pragma warning disable CS8618

namespace Masa.Webaligner.Infrastructure.Options
{
    /// <summary>
    /// Define as opções de strings de conexão da infraestrutura da aplicação.
    /// </summary>
    public class InfrastructureOptions
    {
        /// <summary>
        /// String de conexão para a conta de Blob Storage da aplicação.
        /// </summary>
        public string StorageAccount { get; set; }
        /// <summary>
        /// Opções de conexão para a fila de requisição de alinhamentos da
        /// plataforma.
        /// </summary>
        public MessageBusOptions MessageBus { get; set; }
    }
}
