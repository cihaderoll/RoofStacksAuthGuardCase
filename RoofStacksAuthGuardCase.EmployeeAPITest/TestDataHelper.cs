using RoofStacksAuthGuardCase.EmployeeService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoofStacksAuthGuardCase.EmployeeAPITest
{
    public class TestDataHelper
    {
        public static List<Employee> GetFakeEmployeeList()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Ahmet",
                    LastName = "Doğan"
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Hatice",
                    LastName = "Yılmaz"
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Burcu",
                    LastName = "Akalay"
                }
            };
        }
    }
}
