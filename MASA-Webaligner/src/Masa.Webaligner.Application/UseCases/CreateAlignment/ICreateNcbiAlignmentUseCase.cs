namespace Masa.Webaligner.Application.UseCases.CreateAlignment
{
    /// <summary>
    /// Interface para implementação da criação de alinhamentos via NCBI API.
    /// </summary>
    public interface ICreateNcbiAlignmentUseCase
    {
        /// <summary>
        /// Método de execução do serviço de criação de alinhamentos via NCBI API.
        /// </summary>
        /// <param name="input">Dados do alinhamento requisitado.</param>
        /// <returns>Dados do alinhamento criado.</returns>
        Task<CreateAlignmentOutput?> Execute(CreateNcbiAlignmentInput input);
    }
}
