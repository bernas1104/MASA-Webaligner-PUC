using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Masa.Webaligner.API.Filters
{
    /// <summary>
    /// Filtro para validação das requisições à API
    /// </summary>
    public class ValidationsFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Executa um filtro de validação durante o estágio de 'Action'.
        /// </summary>
        /// <param name="context">Contexto da requisição.</param>
        /// <param name="next">Referencia para o próximo passo do pipeline de execução.</param>
        /// <returns>Não tem retorno.</returns>
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next
        )
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value is not null && x.Value.Errors.Any())
                    .SelectMany(x => x.Value!.Errors.Select(x => x.ErrorMessage));

                var problemDetails = new ProblemDetails
                {
                    Title = "Bad Request",
                    Status = StatusCodes.Status400BadRequest,
                    Instance = context.HttpContext.Request.Path.Value,
                    Detail = String.Join(";", errorsInModelState)
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/problem+json";

                await System.Text.Json.JsonSerializer.SerializeAsync(
                    context.HttpContext.Response.Body,
                    problemDetails
                );

                return;
            }

            await next();
        }
    }
}
