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
        public async Task<OkObjectResult> GetEmployeeListAsync()
        {
            return Ok(await _employeeService.GetEmployeeListAsync());
        }

        [HttpGet("{id}")]
        public async Task<OkObjectResult> GetEmployeeAsync(int id)
        {
            return Ok(await _employeeService.GetEmployeeAsync(id));
        }

        [HttpPost]
        public async Task<OkObjectResult> CreateEmployeeAsync(EmployeeDto employeeData)
        {
            return Ok(await _employeeService.AddOrUpdateEmployeeAsync(employeeData));
        }

        [HttpPut]
        public async Task<OkObjectResult> UpdateEmployeeAsync(EmployeeDto employeeData)
        {
            return Ok(await _employeeService.AddOrUpdateEmployeeAsync(employeeData));
        }

        [HttpDelete("{id}")]
        public async Task<OkObjectResult> DeleteEmployeeAsync(int id)
        {
            return Ok(await _employeeService.DeleteEmployeeAsync(id));
        }
    }
}
