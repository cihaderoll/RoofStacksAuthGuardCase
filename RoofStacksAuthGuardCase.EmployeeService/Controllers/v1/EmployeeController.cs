using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoofStacksAuthGuardCase.EmployeeService.Controllers.Base;
using RoofStacksAuthGuardCase.EmployeeService.DTOs;
using RoofStacksAuthGuardCase.EmployeeService.Services.Abstract;

namespace RoofStacksAuthGuardCase.EmployeeService.Controllers.v1
{
    [Route("api/v1/employee")]
    public class EmployeeController : BaseController
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

        [HttpGet("{id}")]
        public JsonResult GetEmployeeList(int id)
        {
            return new JsonResult(_employeeService.GetEmployee(id));
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
