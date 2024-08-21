using RoofStacksAuthGuardCase.EmployeeService.DTOs;

namespace RoofStacksAuthGuardCase.EmployeeService.Services.Abstract
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets employee list
        /// </summary>
        /// <returns></returns>
        List<EmployeeDto> GetEmployeeList();

        /// <summary>
        /// Adds or updates employee
        /// </summary>
        /// <param name="employeeData"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        bool AddOrUpdateEmployee(EmployeeDto employeeData);

        /// <summary>
        /// Finds and deletes the employee
        /// with the specified id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        bool DeleteEmployee(int employeeId);
    }
}
