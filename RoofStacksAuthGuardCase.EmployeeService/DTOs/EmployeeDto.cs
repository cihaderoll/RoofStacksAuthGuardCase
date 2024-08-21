using RoofStacksAuthGuardCase.EmployeeService.Common;

namespace RoofStacksAuthGuardCase.EmployeeService.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int BirthYear { get; set; }
    }
}
