using Masa.Webaligner.Core.Interfaces.Repositories;
using Masa.Webaligner.Core.Interfaces.UoW;
using Masa.Webaligner.Infrastructure.MessageBus;

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
        private readonly IEventProcessor _eventProcessor;

        /// <summary>
        /// Método construtor de CreateNcbiAlignmentUseCase.
        /// </summary>
        public CreateNcbiAlignmentUseCase(
            IAlignmentsRepository repository,
            IUnitOfWork unitOfWork,
            IEventProcessor eventProcessor
        )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _eventProcessor = eventProcessor;
        }

        /// <summary>
        /// Método de execução do serviço de criação de alinhamentos via NCBI API.
        /// </summary>
        /// <param name="input">Dados do alinhamento requisitado.</param>
        /// <returns>Dados do alinhamento criado.</returns>
        public Task<CreateAlignmentOutput?> Execute(
            BaseCreateAlignmentInput input
        )
        {
            var ncbiAlignmentInput = (CreateNcbiAlignmentInput)input;

            var ncbiAlignment = ncbiAlignmentInput.ToEntity();

            _repository.Add(ncbiAlignment);
            _unitOfWork.Commit();

            _eventProcessor.Process(ncbiAlignment.Events);

            return Task.FromResult(
                CreateAlignmentOutput.FromEntity(ncbiAlignment)
            )!;
        }
    }
}
