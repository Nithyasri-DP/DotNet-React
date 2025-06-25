using AssetManagementSystem.Controllers;
using AssetManagementSystem.DTOs.AuditRequest;
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
    public class AuditRequestsControllerTests
    {
        [Test]
        public async Task Get_ValidId_ReturnsAuditRequest()
        {
            // Arrange
            var mockService = new Mock<IAuditRequestService>();
            var expected = new ReadAuditRequestDTO
            {
                AuditId = 1,
                AssetId = 100,
                Status = "Pending"
            };

            mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(expected);

            var controller = new AuditRequestsController(mockService.Object);
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
            var result = await controller.Get(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var ok = result.Result as OkObjectResult;
            Assert.That(ok!.Value, Is.EqualTo(expected));
        }

        [Test]
        public async Task UpdateStatus_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockService = new Mock<IAuditRequestService>();
            var updateDto = new UpdateAuditRequestDTO { Status = "Verified" };

            mockService.Setup(s => s.UpdateStatusAsync(999, updateDto)).ReturnsAsync(false);

            var controller = new AuditRequestsController(mockService.Object);
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
            var result = await controller.UpdateStatus(999, updateDto);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
            var notFound = result as NotFoundObjectResult;
            Assert.That(notFound!.Value, Is.EqualTo("Audit Request with ID 999 not found or could not update."));
        }
    }
}
