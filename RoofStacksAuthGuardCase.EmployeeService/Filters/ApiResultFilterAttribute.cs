using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RoofStacksAuthGuardCase.EmployeeService.DTOs;
using System.Diagnostics;
using System.Net;

namespace RoofStacksAuthGuardCase.EmployeeService.Filters
{
    public class ApiResultFilterAttribute : IAsyncActionFilter
    {
        /// <summary>
        /// Uygulama içerisindeki bütün response'lar bu filter üzerinden 
        /// (eğer ApiResult tipinde değilse) ApiResult tipine dömüştürülüp
        /// return edilir.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                         ActionExecutionDelegate next)
        {
            var resultContext = await next();
            if (resultContext is not null && resultContext.Result is ObjectResult objectResult)
            {
                if (objectResult.Value is not ApiResult)
                {
                    ApiResult apiResult = new()
                    {
                        Result = objectResult.Value,
                        StatusCode = (int)HttpStatusCode.OK
                    };

                    resultContext.Result = new OkObjectResult(apiResult);
                }
            }
        }
    }
}
