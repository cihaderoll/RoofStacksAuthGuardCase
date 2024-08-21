using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoofStacksAuthGuardCase.EmployeeService.DTOs;
using RoofStacksAuthGuardCase.EmployeeService.Services.Abstract;

namespace RoofStacksAuthGuardCase.EmployeeService.Controllers.v1
{
    [ApiController]
    [Authorize]
    [Route("api/v1/employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public JsonResult GetEmployeeList()
        {
            return new JsonResult(_employeeService.GetEmployeeList());
        }

        [HttpPost]
        public JsonResult CreateEmployee(EmployeeDto employeeData)
        {
            return new JsonResult(_employeeService.AddOrUpdateEmployee(employeeData));
        }

        [HttpPut]
        public JsonResult UpdateEmployee(EmployeeDto employeeData)
        {
            return new JsonResult(_employeeService.AddOrUpdateEmployee(employeeData));
        }
    }
}
