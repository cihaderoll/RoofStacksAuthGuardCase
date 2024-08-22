using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using RoofStacksAuthGuardCase.EmployeeService.DTOs;
using System.Net;

namespace RoofStacksAuthGuardCase.EmployeeService.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Uygulama içerisindeki bütün hata durumları bu handler
        /// üzerinden handle edilir. İlgili tüm alanlara (Elastic, console ve debug console)
        /// log atıldıktan sonra hata mesajını içeren ApiResult return edilir.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            //logging
            _logger.LogError(exception, "An error occured: {Message}", exception.Message);

            ApiResult apiResult = new()
            {
                IsError = true,
            };

            switch (exception)
            {
                case ValidationException valEx:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiResult.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiResult.Message = valEx.Errors.Select(o => o.ErrorMessage).FirstOrDefault();
                    break;
                case UnauthorizedAccessException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    apiResult.StatusCode = (int)HttpStatusCode.Unauthorized;
                    apiResult.Message = exception.Message;
                    break;
                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    apiResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                    apiResult.Message = "Beklenmeyen bir hata meydana geldi";
                    break;
            }

            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(apiResult);

            return true;
        }
    }
}
