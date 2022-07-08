using Masa.Webaligner.Core.Entities;

namespace Masa.Webaligner.Application.UseCases.CreateAlignment
{
    /// <summary>
    /// Informações sobre alinhamento requisitado.
    /// </summary>
    public class CreateAlignmentOutput
    {
        /// <summary>
        /// ID do alinhamento requisitado. Utilizado para visualização dos resultados
        /// após o processamento.
        /// </summary>
        /// <example>F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4</example>
        public string Id { get; init; }
        /// <summary>
        /// Status do alinhamento. Após a requisição do alinhamento, o processamento
        /// pode demorar poucos segundo ou várias horas. Dessa maneira, ao acessar
        /// um alinhamento criado, o status irá informar a situação do processamento.
        ///
        /// Status possíveis:
        /// 0 - Alinhamento requisitado;
        /// 1 - Alinhamento em processamento;
        /// 2 - Alinhamento concluído.
        /// </summary>
        /// <example>1</example>
        public int Status { get; set; }
        /// <summary>
        /// Informa a data de requisição do alinhamento.
        /// </summary>
        /// <example>2022-07-04T23:19:22.376Z</example>
        public DateTime CreatedAt { get; init; }
        /// <summary>
        /// Informa a data da última atualização das informações do alinhamento.
        /// </summary>
        /// <example>2022-07-04T23:19:22.376Z</example>
        public DateTime UpdatedAt { get; init; }

        // TODO Update: demais informações

        private CreateAlignmentOutput(
            string id,
            int status,
            DateTime createdAt,
            DateTime updatedAt
        )
        {
            Id = id;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Retorna os dados do alinhamento requisitado e criado, via NCBI API,
        /// na plataforma.
        /// </summary>
        /// <param name="entity">Dados do alinhamento NCBI criado.</param>
        /// <returns>Dados do alinhamento criado.</returns>
        public static CreateAlignmentOutput FromEntity(Alignment entity)
        {
            return new CreateAlignmentOutput(
                entity.Id.ToString(),
                (int)entity.Status,
                entity.CreatedAt,
                entity.UpdatedAt
            );
        }
    }
}
