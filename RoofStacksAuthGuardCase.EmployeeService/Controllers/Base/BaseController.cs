using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoofStacksAuthGuardCase.EmployeeService.Filters;

namespace RoofStacksAuthGuardCase.EmployeeService.Controllers.Base
{
    [Authorize]
    [ApiController]
    [TypeFilter(typeof(ApiResultFilterAttribute))]
    public class BaseController : ControllerBase
    {
    }
}
