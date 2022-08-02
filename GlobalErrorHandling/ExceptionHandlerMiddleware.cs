using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BankManagement.GlobalErrorHandling
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
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
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            int statusCode = (int)HttpStatusCode.InternalServerError;

            if (exception.GetType().IsAssignableFrom(typeof(NullReferenceException)) ||
                exception.GetType().IsAssignableFrom(typeof(FileNotFoundException)))
            {
                statusCode = (int)HttpStatusCode.NotFound;
            }

            //sonralarda SqlException error lazim ola biler.

            var result = JsonConvert.SerializeObject(new {
                StatusCode = statusCode,
                ErrorMessage = exception.Message
            });
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
