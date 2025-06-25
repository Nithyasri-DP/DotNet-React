using AssetManagementSystem.Controllers;
using AssetManagementSystem.DTOs.Asset;
using AssetManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagementTests.Controllers
{
    [TestFixture]
    public class AssetsControllerTests
    {
        private Mock<IAssetService> _mockService;
        private AssetsController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IAssetService>();
            _controller = new AssetsController(_mockService.Object);
        }

        [Test]
        public async Task GetAvailableAssets_ReturnsListOfAssets()
        {
            // Arrange
            _mockService.Setup(s => s.GetAvailableAssetsAsync())
                .ReturnsAsync(new List<AssetAvailableDTO> {
                    new AssetAvailableDTO { AssetName = "Laptop", CategoryName = "Electronics" }
                });

            // Act
            var result = await _controller.GetAvailableAssets();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetAsset_WhenAssetNotFound_ReturnsNotFound()
        {
            _mockService.Setup(s => s.GetAssetByIdAsync(999)).ReturnsAsync((AssetResponseDTO?)null);

            var result = await _controller.GetAsset(999);

            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
        }
    }
}
