using AssetManagement.Context;
using AssetManagement.DTOs.Auth;
using AssetManagement.Models;
using AssetManagement.Services.Implementations;
using AssetManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NUnitTests.Services
{
    public class AuthServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options = null!;
        private Mock<ITokenService> _tokenServiceMock = null!;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("AuthServiceDb").Options;

            using var context = new ApplicationDbContext(_options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            _tokenServiceMock = new Mock<ITokenService>();
        }
       
        [Test]
        public async Task LoginAsync_ShouldReturnToken_WhenEmployeeLogsIn()
        {
            using var context = new ApplicationDbContext(_options);

            var employee = new User
            {
                UserId = 2,
                Email = "user@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("user123"), 
                FullName = "Employee One",
                Role = new Role { RoleId = 2, RoleName = "Employee" }
            };

            await context.Users.AddAsync(employee);
            await context.SaveChangesAsync();

            var request = new LoginRequest
            {
                Email = "user@gmail.com",
                Password = "user123"
            };

            _tokenServiceMock.Setup(t => t.GenerateToken(It.IsAny<User>())).Returns("employee-jwt-token");

            var service = new AuthService(context, _tokenServiceMock.Object);
            var result = await service.LoginAsync(request);

            Assert.That(result, Is.EqualTo("employee-jwt-token"));
        }
    }
}
