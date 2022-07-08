using System.Text.Json.Serialization;
using Masa.Webaligner.Core.Entities;
using Masa.Webaligner.Core.Enums;

namespace Masa.Webaligner.Application.UseCases.CreateAlignment
{
    /// <summary>
    /// Classe abstrata com as informações comuns a criação de todos os tipos de
    /// alinhamento no sistema.
    /// </summary>
    public abstract class BaseCreateAlignmentInput
    {
        /// <summary>
        /// E-mail de contato do usuário. Utilizado para informar o usuário sobre
        /// a conclusão do alinhamento requisitado.
        /// </summary>
        /// <example>john@gmail.com</example>
        public string? Email { get; init; }
        /// <summary>
        /// Primeiro nome do usuário requerente do alinhamento.
        /// </summary>
        /// <example>John</example>
        public string? FirstName { get; init; }
        /// <summary>
        /// Último nome do usuário requerente do alinhamento.
        /// </summary>
        /// <example>Doe</example>
        public string? LastName { get; init; }
        /// <summary>
        /// Informa se o usuário pretende executar apenas o Estágio I ou todos
        /// os estágios do processo de alinhamento. Default: false - executa todos
        /// os estágios por padrão.
        /// </summary>
        /// <example>false</example>
        public bool OnlyStageI { get; init; } = false;
        /// <summary>
        /// Atributo somente leitura para o nome completo do usuário requerente.
        /// Utiliza os atributos 'FirstName' e 'LastName'.
        /// </summary>
        /// <returns>Composição do nome completo do usuário requerente.</returns>
        [JsonIgnore]
        public string FullName { get => (FirstName ?? "") + (LastName ?? ""); }
    }

    /// <summary>
    /// Informações para criação de um alinhamento por meio da NCBI API.
    /// </summary>
    public class CreateNcbiAlignmentInput : BaseCreateAlignmentInput
    {
        /// <summary>
        /// Nome da primeira sequencia .FASTA a ser buscada na API do NCBI.
        /// </summary>
        /// <example>MT126808.1</example>
        public string? FirstSequenceName { get; init; }
        /// <summary>
        /// Nome da segunda sequencia .FASTA a ser buscada na API do NCBI.
        /// </summary>
        /// <example>NC_045512.2</example>
        public string? SecondSequenceName { get; init; }

        /// <summary>
        /// Método tipo 'Factory' para gerarção de instancia da entidade
        /// 'NcbiAlignment'.
        /// </summary>
        /// <returns>Retorna uma instancia de 'NcbiAlignment'.</returns>
        public Alignment ToEntity()
        {
            return new NcbiAlignment(
                new User(null, Email!, FirstName!, LastName),
                OnlyStageI,
                AlignmentStatus.Requested,
                FirstSequenceName!,
                SecondSequenceName!
            );
        }
    }
}
