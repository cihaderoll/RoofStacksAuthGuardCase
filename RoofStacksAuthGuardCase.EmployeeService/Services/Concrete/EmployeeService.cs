using Microsoft.EntityFrameworkCore;
using RoofStacksAuthGuardCase.EmployeeService.Context;
using RoofStacksAuthGuardCase.EmployeeService.DTOs;
using RoofStacksAuthGuardCase.EmployeeService.Services.Abstract;

namespace RoofStacksAuthGuardCase.EmployeeService.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<EmployeeDto> GetEmployeeList()
        {
            var employeeData = _appDbContext.Employees.AsNoTracking().Select(o => new EmployeeDto
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Gender = o.Gender
            }).ToList();

            return employeeData;
        }

        public EmployeeDto GetEmployee(int id)
        {
            var employeeData = _appDbContext.Employees
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Select(o => new EmployeeDto
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Gender = o.Gender
            }).FirstOrDefault();

            return employeeData;
        }
        
        public bool AddOrUpdateEmployee(EmployeeDto employeeData)
        {
            //validations take place here for simplicity
            if (!ValidateEmployeeData(employeeData))
                return false;
                
            return employeeData.Id > 0 ? UpdateEmployee(employeeData) : AddEmployee(employeeData);
        }

        private bool AddEmployee(EmployeeDto employeeData)
        {
            _appDbContext.Employees.Add(new Model.Employee
            {
                FirstName = employeeData.FirstName,
                LastName = employeeData.LastName,
                Gender = employeeData.Gender,
            });

            return _appDbContext.SaveChanges() > 0;
        }

        private bool UpdateEmployee(EmployeeDto employeeData)
        {
            var employee = _appDbContext.Employees.FirstOrDefault(o => o.Id == employeeData.Id);
            if (employee == null)
                return false;

            employee.FirstName = employeeData.FirstName;
            employee.LastName = employeeData.LastName;
            employee.Gender = employeeData.Gender;

            return _appDbContext.SaveChanges() > 0;
        }

        private bool ValidateEmployeeData(EmployeeDto employeeData)
        {
            if(string.IsNullOrEmpty(employeeData.FirstName) || 
                string.IsNullOrEmpty(employeeData.LastName) ||
                employeeData.BirthYear <= 0)
                return false;

            return true;
        }

        public bool DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
