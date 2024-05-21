using Pronabec.UseCases.Common.Bases;
using Pronabec.UseCases.Common.Exceptions;
using System.Text.Json;

namespace Pronabec.WebApi.Modules.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationExceptionCustom ex)
            {
                context.Response.ContentType= "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, 
                    new BaseResponse<Object> { Message = "Errores de Validación", Errors = ex.Errors });
            }
        }
    }
}
