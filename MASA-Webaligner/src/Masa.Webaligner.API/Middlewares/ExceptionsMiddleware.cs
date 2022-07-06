using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Masa.Webaligner.API.Middlewares
{
    /// <summary>
    /// Middleware responsável por capturar exceptions não tratadas pelo
    /// usuário.
    /// </summary>
    public class ExceptionsMiddleware
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        /// <summary>
        /// Método construtor do ExceptionsMiddleware.
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public ExceptionsMiddleware(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Método responsável pela execução do middleware de exceptions.
        /// </summary>
        /// <param name="context">Contexto da requisição HTTP.</param>
        /// <returns>Sem retorno.</returns>
        public async Task Invoke(HttpContext context)
        {
            var exception = context.Features
                .Get<IExceptionHandlerFeature>()?
                .Error;

            if (exception is null)
            {
                return;
            }

            var problemDetails = new ProblemDetails
            {
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError,
                Instance = context.Request.Path.Value,
                Detail = exception.InnerException is null ?
                    $"{exception.Message}" :
                    $"{exception.Message} | {exception.InnerException}"
            };

            if (_webHostEnvironment.IsDevelopment())
            {
                problemDetails.Detail += $": {exception.StackTrace}";
            }

            context.Response.StatusCode = problemDetails.Status.Value;
            context.Response.ContentType = "application/problem+json";

            await System.Text.Json.JsonSerializer.SerializeAsync(
                context.Response.Body,
                problemDetails
            );
        }
    }
}
