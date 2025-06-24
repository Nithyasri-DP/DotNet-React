using AssetManagementSystem.Context;
using AssetManagementSystem.Controllers;
using AssetManagementSystem.DTOs.Auth;
using AssetManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace AssetManagementTests.Controllers
{
    [TestFixture]
    public class AuthControllerTests
    {
        private Mock<IConfiguration> _mockConfig = null!;

        [SetUp]
        public void Setup()
        {
            _mockConfig = new Mock<IConfiguration>();
            _mockConfig.Setup(c => c["Jwt:Key"]).Returns("testkey12345678901234567890");
            _mockConfig.Setup(c => c["Jwt:Issuer"]).Returns("TestIssuer");
            _mockConfig.Setup(c => c["Jwt:Audience"]).Returns("TestAudience");
        }

        private static AssetDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AssetDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AssetDbContext(options);
        }
        [Test]
        public void Login_ValidCredentials_ReturnsToken()
        {
            // Arrange
            using var dbContext = GetInMemoryDbContext();
            dbContext.Employees.Add(new Employee
            {
                EmployeeId = 1,
                Email = "user@test.com",
                Password = "123456",
                Role = "Employee",
                EmployeeName = "Test User"
            });
            dbContext.SaveChanges();

            var mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(c => c["Jwt:Key"]).Returns("thisisaverysecurejwtkeythatis32bytes!");
            mockConfig.Setup(c => c["Jwt:Issuer"]).Returns("TestIssuer");
            mockConfig.Setup(c => c["Jwt:Audience"]).Returns("TestAudience");

            var controller = new AuthController(dbContext, mockConfig.Object);

            var dto = new LoginDTO
            {
                Email = "user@test.com",
                Password = "123456"
            };

            // Act
            var result = controller.Login(dto) as OkObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.StatusCode, Is.EqualTo(200));

            // Convert anonymous object to dictionary
            var tokenValue = result.Value?.GetType().GetProperty("token")?.GetValue(result.Value, null);

            Assert.That(tokenValue, Is.Not.Null, "Token not found");
            Assert.That(tokenValue, Is.TypeOf<string>(), "Token is not a valid string");
        }



        [Test]
        public async Task ForgotPassword_EmailNotFound_ReturnsBadRequest()
        {
            // Arrange
            using var dbContext = GetInMemoryDbContext();
            var controller = new AuthController(dbContext, _mockConfig.Object);

            var dto = new ForgotPasswordDTO
            {
                Email = "invalid@none.com"
            };

            // Act
            var result = await controller.ForgotPassword(dto) as BadRequestObjectResult;

            // Assert using constraint model
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.StatusCode, Is.EqualTo(400));
            Assert.That(result.Value, Is.EqualTo("Email not found."));
        }
    }
}
