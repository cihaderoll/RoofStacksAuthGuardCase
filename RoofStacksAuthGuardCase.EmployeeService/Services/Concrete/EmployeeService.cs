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

        public async Task<List<EmployeeDto>> GetEmployeeListAsync()
        {
            var employeeData = await _appDbContext.Employees.AsNoTracking().Select(o => new EmployeeDto
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Gender = o.Gender
            }).ToListAsync();

            return employeeData;
        }

        public async Task<EmployeeDto> GetEmployeeAsync(int id)
        {
            var employeeData = await _appDbContext.Employees
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Select(o => new EmployeeDto
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Gender = o.Gender
            }).FirstOrDefaultAsync();

            return employeeData ?? throw new Exception("Kayıt Bulunamadı.");
        }

        public async Task<bool> AddOrUpdateEmployeeAsync(EmployeeDto employeeData)
        {
            //validations take place here for simplicity
            if (!ValidateEmployeeData(employeeData))
                return false;
                
            return employeeData.Id > 0 ? await UpdateEmployeeAsync(employeeData) : await AddEmployeeAsync(employeeData);
        }

        private async Task<bool> AddEmployeeAsync(EmployeeDto employeeData)
        {
            await _appDbContext.Employees.AddAsync(new Model.Employee
            {
                FirstName = employeeData.FirstName,
                LastName = employeeData.LastName,
                Gender = employeeData.Gender,
            });

            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        private async Task<bool> UpdateEmployeeAsync(EmployeeDto employeeData)
        {
            var employee = await _appDbContext.Employees.FirstOrDefaultAsync(o => o.Id == employeeData.Id);
            if (employee == null)
                return false;

            employee.FirstName = employeeData.FirstName;
            employee.LastName = employeeData.LastName;
            employee.Gender = employeeData.Gender;

            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        private bool ValidateEmployeeData(EmployeeDto employeeData)
        {
            if(string.IsNullOrEmpty(employeeData.FirstName) || 
                string.IsNullOrEmpty(employeeData.LastName))
                return false;

            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var employeeData = await _appDbContext.Employees.FirstOrDefaultAsync(o => o.Id == employeeId);
            if (employeeData == null)
                throw new Exception("Kayıt bulunamadı");

            _appDbContext.Employees.Remove(employeeData);
            if((await _appDbContext.SaveChangesAsync()) <= 0)
                throw new Exception("İşlem esnasında bir sorun oluştu");

            return true;
        }
    }
}
