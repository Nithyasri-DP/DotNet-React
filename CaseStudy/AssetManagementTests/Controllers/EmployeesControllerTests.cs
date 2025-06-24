using AssetManagementSystem.Context;
using AssetManagementSystem.Controllers;
using AssetManagementSystem.DTOs.Employee;
using AssetManagementSystem.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace AssetManagementSystem.Tests.Controllers
{
    [TestFixture]
    public class EmployeesControllerTests
    {
        [Test]
        public async Task GetEmployees_ReturnsAllEmployees()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AssetDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new AssetDbContext(options);
            dbContext.Employees.AddRange(new List<Employee>
            {
                new Employee { EmployeeId = 1, Email = "a@test.com", Password = "123", Role = "Employee", EmployeeName = "Alice" },
                new Employee { EmployeeId = 2, Email = "b@test.com", Password = "456", Role = "Employee", EmployeeName = "Bob" }
            });
            dbContext.SaveChanges();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, ReadEmployeeDTO>();
            });
            var mapper = config.CreateMapper();

            var controller = new EmployeesController(dbContext, mapper);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.NameIdentifier, "1")
                    }, "mock"))
                }
            };

            // Act
            var result = await controller.GetEmployees();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult!.Value, Is.InstanceOf<List<ReadEmployeeDTO>>());

            var dtoList = okResult.Value as List<ReadEmployeeDTO>;
            Assert.That(dtoList!.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task CreateEmployee_AdminCannotCreateAdmin_Returns403()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AssetDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new AssetDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateEmployeeDTO, Employee>();
            });
            var mapper = config.CreateMapper();

            var controller = new EmployeesController(dbContext, mapper);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.NameIdentifier, "1")
                    }, "mock"))
                }
            };

            var dto = new CreateEmployeeDTO
            {
                Email = "admin2@test.com",
                Password = "adminpass",
                Role = "Admin",
                EmployeeName = "Second Admin"
            };

            // Act
            var actionResult = await controller.CreateEmployee(dto);
            var result = actionResult.Result as ObjectResult;


            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.StatusCode, Is.EqualTo(403));
            Assert.That(result.Value, Is.EqualTo("Only SuperAdmins can create Admins."));
        }
    }
}
