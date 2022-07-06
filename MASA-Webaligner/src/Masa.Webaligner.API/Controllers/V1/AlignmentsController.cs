using System.Net;
using Masa.Webaligner.Application.UseCases.CreateAlignment;
using Microsoft.AspNetCore.Mvc;

namespace Masa.Webaligner.API.Controllers.V1
{
    /// <summary>
    /// Controller de Alignments. Responsável por implementar todas as Actions
    /// sobre o recurso "Alignment".
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class AlignmentsController : Controller
    {
        private readonly ILogger<AlignmentsController> _logger;

        /// <summary>
        /// Método construtor de AlignmentsController.
        /// </summary>
        /// <param name="logger">Módulo para criação de logs sobre as Actions.</param>
        public AlignmentsController(ILogger<AlignmentsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Realiza a requisição de um alinhamento de sequencias genéticas e
        /// obtém as sequencias via NCBI API a partir dos nomes informados no
        /// corpo da requisição.
        /// </summary>
        /// <param name="input">Dados do alinhamento.</param>
        /// <param name="service">Serviço responsável por processar a requisção.</param>
        /// <returns>O ID, status e a data de criação da requisição de alinhamento.</returns>
        /// <response code="201">O ID, status e a data de criação da requisição de alinhamento.</response>
        /// <response code="400">Requisição inválida.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [ProducesResponseType(typeof(CreateAlignmentOutput), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostNcbi(
            [FromBody] CreateNcbiAlignmentInput input,
            [FromServices] ICreateNcbiAlignmentUseCase service
        )
        {
            var createdAlignment = await service.Execute(input);
            if (createdAlignment is null)
            {
                return BadRequest();
            }

            return Created(nameof(GetById), createdAlignment);
        }

        /// <summary>
        /// Busca as informações sobre um alinhamento no sistema. A busca é
        /// realizada por meio do GUID do alinhamento.
        /// </summary>
        /// <param name="id">GUID do alinhamento.</param>
        /// <returns>Informações sobre o alinhamento.</returns>
        /// <response code="200">Informações sobre o alinhamento.</response>
        /// <response code="404">Alinhamento não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CreateAlignmentOutput), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public Task<IActionResult> GetById([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
