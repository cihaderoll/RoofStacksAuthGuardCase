using RoofStacksAuthGuardCase.EmployeeService.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoofStacksAuthGuardCase.EmployeeService.Model
{
    [Table("employee", Schema = "company")]
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
    }
}
