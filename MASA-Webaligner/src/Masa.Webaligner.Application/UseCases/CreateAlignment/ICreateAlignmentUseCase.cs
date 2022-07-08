namespace Masa.Webaligner.Application.UseCases.CreateAlignment
{
    /// <summary>
    /// Interface para implementação da criação de alinhamentos.
    /// </summary>
    public interface ICreateAlignmentUseCase
    {
        /// <summary>
        /// Método de execução do serviço de criação de alinhamentos.
        /// </summary>
        /// <param name="input">Dados do alinhamento requisitado.</param>
        /// <returns>Dados do alinhamento criado.</returns>
        Task<CreateAlignmentOutput?> Execute(BaseCreateAlignmentInput input);
    }
}
