using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;
using RoofStacksAuthGuardCase.EmployeeService.Context;
using RoofStacksAuthGuardCase.EmployeeService.Controllers.v1;
using RoofStacksAuthGuardCase.EmployeeService.DTOs;
using RoofStacksAuthGuardCase.EmployeeService.Model;
using RoofStacksAuthGuardCase.EmployeeService.Services.Abstract;
using RoofStacksAuthGuardCase.EmployeeService.Services.Concrete;

namespace RoofStacksAuthGuardCase.EmployeeAPITest
{
    public class EmployeeServiceTest
    {
        private readonly Mock<IEmployeeService> _employeeMoqService;
        private IEmployeeService _employeeService;
        private readonly EmployeeController _employeeController;

        public EmployeeServiceTest()
        {
            _employeeMoqService = new Mock<IEmployeeService>();
            _employeeController = new EmployeeController(_employeeMoqService.Object);
        }

        [Fact]
        public async Task EmployeeService_GetEmployeeListAsync_ShouldReturnEmployeeList()
        {
            // Arrange
            _employeeMoqService.Setup(service => service.GetEmployeeListAsync())
                .ReturnsAsync(new List<EmployeeDto> 
                    { 
                        new EmployeeDto
                        {
                            Id = 1,
                            FirstName = "Cihad",
                            LastName = "Erol",
                            Gender = EmployeeService.Common.Gender.Male
                        }
                    });

            // Act
            var result = await _employeeMoqService.Object.GetEmployeeListAsync();

            // Assert
            Assert.IsType<List<EmployeeDto>>(result);
        }

        [Fact]
        public async Task EmployeeService_GetEmployeeAsync_ShouldReturnEmployeeList()
        {
            var id = 1;

            // Arrange
            _employeeMoqService.Setup(service => service.GetEmployeeAsync(id))
                .ReturnsAsync(
                        new EmployeeDto
                        {
                            Id = 1,
                            FirstName = "Cihad",
                            LastName = "Erol",
                            Gender = EmployeeService.Common.Gender.Male
                        }
                    );

            // Act
            var result = await _employeeMoqService.Object.GetEmployeeAsync(id);

            // Assert
            Assert.IsType<EmployeeDto>(result);
            Assert.True(result.Id == 1);
        }
        
        [Fact]
        public async Task EmployeeService_CreateEmployeeAsync_ShouldReturnEmployeeList()
        {
            var newEmployee = new EmployeeDto
            {
                FirstName = "Aydýn",
                LastName = "Uzun"
            };

            // Arrange
            var employeeCtx = new Mock<AppDbContext>();
            employeeCtx.Setup(x => x.Employees)
                .ReturnsDbSet(TestDataHelper.GetFakeEmployeeList());

            employeeCtx.Setup(x => x.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(1);

            _employeeService = new EmployeeService.Services.Concrete.EmployeeService(employeeCtx.Object);

            //_employeeMoqService.Setup(service => service.AddOrUpdateEmployeeAsync(newEmployee))
            //    .ReturnsAsync(
            //            new EmployeeDto
            //            {
            //                Id = 1,
            //                FirstName = "Cihad",
            //                LastName = "Erol",
            //                Gender = EmployeeService.Common.Gender.Male
            //            }
            //        );

            // Act
            var result = await _employeeService.AddOrUpdateEmployeeAsync(newEmployee);

            // Assert
            Assert.True(result);
        }
    }
}