using Masa.Webaligner.Core.Interfaces.Repositories;
using Masa.Webaligner.Core.Interfaces.UoW;

namespace Masa.Webaligner.Application.UseCases.CreateAlignment
{
    /// <summary>
    /// Implementação, segundo "ICreateNcbiAlignmentUseCase" interface, da criação
    /// de alinhamentos via NCBI API.
    /// </summary>
    public class CreateNcbiAlignmentUseCase : ICreateNcbiAlignmentUseCase
    {
        private readonly IAlignmentsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Método construtor de CreateNcbiAlignmentUseCase.
        /// </summary>
        public CreateNcbiAlignmentUseCase(
            IAlignmentsRepository repository,
            IUnitOfWork unitOfWork
        )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Método de execução do serviço de criação de alinhamentos via NCBI API.
        /// </summary>
        /// <param name="input">Dados do alinhamento requisitado.</param>
        /// <returns>Dados do alinhamento criado.</returns>
        public Task<CreateAlignmentOutput?> Execute(
            CreateNcbiAlignmentInput input
        )
        {
            throw new NotImplementedException();
        }
    }
}
