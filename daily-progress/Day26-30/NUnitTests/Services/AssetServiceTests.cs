using AssetManagement.Context;
using AssetManagement.DTOs.Asset;
using AssetManagement.Models;
using AssetManagement.Services.Implementations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUnitTests.Services
{
    public class AssetServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options = null!;
        private Mock<IMapper> _mapperMock = null!;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("AssetServiceDb").Options;

            using var context = new ApplicationDbContext(_options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public async Task CreateAssetAsync_ShouldReturnAssetId_WhenAssetIsSaved()
        {
            using var context = new ApplicationDbContext(_options);

            var dto = new AssetCreateDto
            {
                AssetName = "Laptop",
                Quantity = 5,
                CategoryId = 1,
                ManufacturingDate = new DateTime(2021, 1, 1),
                ExpiryDate = DateTime.UtcNow.AddYears(3),
                AssetModel = "Dell 5400",
                AssetValue = 75000
            };

            var asset = new Asset
            {
                AssetId = 1,
                AssetName = dto.AssetName,
                Quantity = dto.Quantity,
                CategoryId = dto.CategoryId,
                ManufacturingDate = dto.ManufacturingDate,
                ExpiryDate = dto.ExpiryDate,
                AssetModel = dto.AssetModel,
                AssetValue = dto.AssetValue
            };

            _mapperMock.Setup(m => m.Map<Asset>(dto)).Returns(asset);

            var service = new AssetService(context, _mapperMock.Object);
            var assetId = await service.CreateAssetAsync(dto);

            Assert.That(assetId, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetAvailableAssetsForEmployeeAsync_ShouldReturnNonEmptyList_WhenAssetsExist()
        {
            using var context = new ApplicationDbContext(_options);

            var assets = new List<Asset>
            {
                new Asset { AssetId = 1, AssetName = "Laptop", Quantity = 3, IsDeleted = false },
                new Asset { AssetId = 2, AssetName = "Mouse", Quantity = 5, IsDeleted = false }
            };

            await context.Assets.AddRangeAsync(assets);
            await context.SaveChangesAsync();

            var mapped = new List<AssetAvailableDto>
            {
                new AssetAvailableDto { AssetId = 1, AssetName = "Laptop" },
                new AssetAvailableDto { AssetId = 2, AssetName = "Mouse" }
            };

            _mapperMock.Setup(m => m.Map<IEnumerable<AssetAvailableDto>>(It.IsAny<List<Asset>>())).Returns(mapped);

            var service = new AssetService(context, _mapperMock.Object);
            var result = await service.GetAvailableAssetsForEmployeeAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAssetByIdAsync_ShouldReturnNull_WhenAssetNotFound()
        {
            using var context = new ApplicationDbContext(_options);
            var service = new AssetService(context, _mapperMock.Object);

            var result = await service.GetAssetByIdAsync(99);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task DeleteAssetAsync_ShouldReturnTrue_WhenAssetExists()
        {
            using var context = new ApplicationDbContext(_options);

            var asset = new Asset { AssetId = 1, AssetName = "Tablet", Quantity = 2, IsDeleted = false };
            await context.Assets.AddAsync(asset);
            await context.SaveChangesAsync();

            var service = new AssetService(context, _mapperMock.Object);
            var result = await service.DeleteAssetAsync(1);

            var deleted = await context.Assets.FindAsync(1);

            Assert.That(result, Is.True);
            Assert.That(deleted?.IsDeleted, Is.True);
        }
    }
}
