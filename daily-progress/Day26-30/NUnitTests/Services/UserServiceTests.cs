using AssetManagement.Context;
using AssetManagement.DTOs.User;
using AssetManagement.Models;
using AssetManagement.Services.Implementations;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUnitTests.Services
{
    public class UserServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options = null!;
        private Mock<IMapper> _mapperMock = null!;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("UserServiceDb").Options;

            using var context = new ApplicationDbContext(_options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public async Task CreateEmployeeAsync_ShouldAddEmployee_WhenEmailIsUnique()
        {
            var role = new Role { RoleId = 2, RoleName = "Employee" };

            using var context = new ApplicationDbContext(_options);
            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();

            var dto = new CreateEmployeeDto
            {
                Email = "user@gmail.com",
                FullName = "Test User",
                Password = "Test@123",
                PhoneNumber = "1234567890",
                RoleName = "Employee"
            };

            var user = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber
            };

            _mapperMock.Setup(m => m.Map<User>(dto)).Returns(user);

            var service = new UserService(context, _mapperMock.Object);
            var result = await service.CreateEmployeeAsync(dto);

            Assert.That(result, Is.EqualTo("Employee created successfully."));
            Assert.That(context.Users.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CreateEmployeeAsync_ShouldThrow_WhenEmailExists()
        {
            using var context = new ApplicationDbContext(_options);
            context.Users.Add(new User { Email = "user@gmail.com" });
            context.SaveChanges();

            var dto = new CreateEmployeeDto { Email = "user@gmail.com" };
            var service = new UserService(context, _mapperMock.Object);

            Assert.ThrowsAsync<BadHttpRequestException>(() => service.CreateEmployeeAsync(dto));
        }

        [Test]
        public async Task GetOwnProfileAsync_ShouldReturnMappedUserDto()
        {
            using var context = new ApplicationDbContext(_options);

            var role = new Role { RoleId = 1, RoleName = "Employee" };
            await context.Roles.AddAsync(role);

            var user = new User
            {
                UserId = 1,
                Email = "user@test.com",
                RoleId = role.RoleId,
                Role = role
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            var expectedDto = new UserDto { UserId = 1, Email = "user@test.com" };
            _mapperMock.Setup(m => m.Map<UserDto>(user)).Returns(expectedDto);

            var service = new UserService(context, _mapperMock.Object);
            var result = await service.GetOwnProfileAsync(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result?.Email, Is.EqualTo("user@test.com"));
        }

        [Test]
        public async Task SoftDeleteEmployeeAsync_ShouldMarkUserAsDeleted()
        {
            using var context = new ApplicationDbContext(_options);
            var user = new User { UserId = 2, Email = "soft@x.com", IsDeleted = false };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            var service = new UserService(context, _mapperMock.Object);
            var result = await service.SoftDeleteEmployeeAsync(2);

            var deletedUser = await context.Users.FindAsync(2);
            Assert.That(result, Is.EqualTo("Employee soft deleted successfully."));
            Assert.That(deletedUser?.IsDeleted, Is.True);
        }
    }
}
