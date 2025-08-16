using Application.Interfaces;
using System.Net;
using System.Text.Json;

namespace Finaktiva_Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;

        public ExceptionMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILoggingService>();
                    await logger.LogInfoAsync("Iniciando manejo de excepción");
                }

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Ocurrió un error inesperado.");
            }
        }
    }

}
