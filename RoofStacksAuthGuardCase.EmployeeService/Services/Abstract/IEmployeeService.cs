using RoofStacksAuthGuardCase.EmployeeService.DTOs;

namespace RoofStacksAuthGuardCase.EmployeeService.Services.Abstract
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets employee list
        /// </summary>
        /// <returns></returns>
        Task<List<EmployeeDto>> GetEmployeeListAsync();

        /// <summary>
        /// Retrieves employee data with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmployeeDto> GetEmployeeAsync(int id);

        /// <summary>
        /// Adds or updates employee
        /// </summary>
        /// <param name="employeeData"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<bool> AddOrUpdateEmployeeAsync(EmployeeDto employeeData);

        /// <summary>
        /// Finds and deletes the employee
        /// with the specified id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<bool> DeleteEmployeeAsync(int employeeId);
    }
}
