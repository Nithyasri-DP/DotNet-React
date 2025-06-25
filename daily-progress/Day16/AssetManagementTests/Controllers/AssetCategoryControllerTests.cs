using AssetManagementSystem.Controllers;
using AssetManagementSystem.DTOs.AssetCategory;
using AssetManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssetManagementSystem.Tests.Controllers
{
    [TestFixture]
    public class AssetCategoryControllerTests
    {
        [Test]
        public async Task GetCategory_ValidId_ReturnsOkWithCategory()
        {
            // Arrange
            var mockService = new Mock<IAssetCategoryService>();
            var category = new ReadAssetCategoryDTO
            {
                AssetCategoryId = 1,
                CategoryName = "Laptops"
            };

            mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(category);

            var controller = new AssetCategoryController(mockService.Object);
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
            var result = await controller.GetCategory(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var ok = result.Result as OkObjectResult;
            Assert.That(ok!.Value, Is.EqualTo(category));
        }

        [Test]
        public async Task DeleteCategory_InvalidId_ReturnsBadRequest()
        {
            // Arrange
            var mockService = new Mock<IAssetCategoryService>();
            mockService.Setup(s => s.DeleteAsync(999)).ReturnsAsync(false); 

            var controller = new AssetCategoryController(mockService.Object);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Role, "SuperAdmin")
                    }, "mock"))
                }
            };

            // Act
            var result = await controller.DeleteCategory(999);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var bad = result as BadRequestObjectResult;
            Assert.That(bad!.Value, Is.EqualTo("Category not found or already assigned to assets."));
        }
    }
}
