using Microsoft.AspNetCore.Http;
using SimpleService.Core.Exceptions;
using SimpleService.Infrastructure.Exceptions;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleService.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex);
            }
        }

        private async Task HandleAsync(HttpContext context, Exception exeption)
        {
            context.Response.ContentType = "text/html";

            switch (exeption)
            {
                case UnauthorizedException _:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await AddMessageToBody(context.Response, exeption.Message);
                    break;
                case NotFoundException _:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await AddMessageToBody(context.Response, exeption.Message);
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await AddMessageToBody(context.Response, "Internal Server error");
                    break;
            }
        }

        private static ValueTask AddMessageToBody(HttpResponse response, string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            return response.Body.WriteAsync(bytes.AsMemory(0, bytes.Length));
        }
    }
}
