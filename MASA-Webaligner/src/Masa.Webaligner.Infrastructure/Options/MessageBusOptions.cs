#pragma warning disable CS8618

namespace Masa.Webaligner.Infrastructure.Options
{
    /// <summary>
    /// Define as opções de conexão do Message Bus da aplicação.
    /// </summary>
    public class MessageBusOptions
    {
        /// <summary>
        /// Host name do Message Bus.
        /// </summary>
        /// <example>localhost</example>
        public string HostName { get; set; }
        /// <summary>
        /// Nome de usuário para conexão com o Message Bus.
        /// </summary>
        /// <example>guest</example>
        public string UserName { get; set; }
        /// <summary>
        /// Senha do usuário para conexão com o Message Bus.
        /// </summary>
        /// <example>guest</example>
        public string Password { get; set; }
        /// <summary>
        /// String de conexão com o Message Bus (Azure Service Bus).
        /// </summary>
        /// <example>TBD</example>
        public string? ConnectionString { get; set; }
    }
}
