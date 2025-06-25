using AssetManagementSystem.Controllers;
using AssetManagementSystem.DTOs.ServiceRequest;
using AssetManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssetManagementSystem.Tests.Controllers
{
    [TestFixture]
    public class ServiceRequestsControllerTests
    {
        [Test]
        public async Task Create_ValidRequest_ReturnsCreated()
        {
            // Arrange
            var mockService = new Mock<IServiceRequestService>();
            var createDto = new CreateServiceRequestDTO
            {
                AssetId = 1,
                Description = "Battery issue"
            };

            var readDto = new ReadServiceRequestDTO
            {
                RequestId = 101,
                AssetId = 1,
                Description = "Battery issue",
                Status = "Pending"
            };

            mockService.Setup(s => s.CreateAsync(createDto)).ReturnsAsync(readDto);

            var controller = new ServiceRequestsController(mockService.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Role, "Employee")
                    }, "mock"))
                }
            };

            // Act
            var result = await controller.Create(createDto);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());
            var created = result.Result as CreatedAtActionResult;
            Assert.That(created!.Value, Is.EqualTo(readDto));
        }

        [Test]
        public async Task UpdateStatus_RequestNotFound_Returns404()
        {
            // Arrange
            var mockService = new Mock<IServiceRequestService>();
            var updateDto = new UpdateServiceRequestDTO { Status = "Resolved" };

            mockService.Setup(s => s.UpdateStatusAsync(999, updateDto)).ReturnsAsync(false); // Simulate not found

            var controller = new ServiceRequestsController(mockService.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Role, "Admin")
                    }, "mock"))
                }
            };

            // Act
            var result = await controller.UpdateStatus(999, updateDto);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
            var notFound = result as NotFoundObjectResult;
            Assert.That(notFound!.Value, Is.EqualTo("Service request with ID 999 not found."));
        }
    }
}
