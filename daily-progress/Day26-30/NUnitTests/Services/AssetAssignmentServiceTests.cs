using AssetManagement.Context;
using AssetManagement.DTOs.Asset;
using AssetManagement.Models;
using AssetManagement.Services.Implementations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUnitTests.Services
{
    public class AssetAssignmentServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options = null!;
        private Mock<IMapper> _mapperMock = null!;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("AssetAssignmentTestDb").Options;

            using var context = new ApplicationDbContext(_options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public async Task RequestAssetAsync_ShouldReturnSuccessMessage_WhenAssetExists()
        {
            using var context = new ApplicationDbContext(_options);
            var asset = new Asset { AssetId = 1, AssetName = "Monitor", Quantity = 10, IsDeleted = false };
            await context.Assets.AddAsync(asset);
            await context.SaveChangesAsync();

            var service = new AssetAssignmentService(context, _mapperMock.Object);

            var result = await service.RequestAssetAsync(1, new AssetRequestDto
            {
                AssetId = 1,
                Quantity = 2
            });

            Assert.That(result, Is.EqualTo("Asset request submitted."));
        }

        [Test]
        public async Task AssignAssetAsync_ShouldAssign_WhenAssetQuantityIsSufficient()
        {
            using var context = new ApplicationDbContext(_options);

            var asset = new Asset { AssetId = 1, AssetName = "Keyboard", Quantity = 5, IsDeleted = false };
            var assignment = new AssetAssignment
            {
                AssignmentId = 1,
                AssetId = 1,
                Asset = asset,
                Quantity = 2,
                Status = "Requested",
                IsDeleted = false
            };

            await context.Assets.AddAsync(asset);
            await context.AssetAssignments.AddAsync(assignment);
            await context.SaveChangesAsync();

            var service = new AssetAssignmentService(context, _mapperMock.Object);
            var result = await service.AssignAssetAsync(new AssetAssignInputDto
            {
                AssignmentId = 1,
                AssignedDate = DateTime.Now
            });

            Assert.That(result, Is.EqualTo("Asset assigned successfully."));
        }

        [Test]
        public async Task RequestReturnAsync_ShouldChangeStatus_WhenAssignmentIsAssigned()
        {
            using var context = new ApplicationDbContext(_options);

            var assignment = new AssetAssignment
            {
                AssignmentId = 1,
                AssetId = 1,
                UserId = 123,
                Quantity = 1,
                Status = "Assigned",
                ReturnStatus = "" 
            };

            await context.AssetAssignments.AddAsync(assignment);
            await context.SaveChangesAsync();

            var service = new AssetAssignmentService(context, _mapperMock.Object);
            var result = await service.RequestReturnAsync(1, 123);

            Assert.That(result, Is.EqualTo("Return request submitted successfully."));

            var updated = await context.AssetAssignments.FindAsync(1);
            Assert.That(updated?.ReturnStatus, Is.EqualTo("Requested")); 
        }

        [Test]
        public async Task ApproveReturnAsync_ShouldUpdateInventoryAndStatus()
        {
            using var context = new ApplicationDbContext(_options);

            var asset = new Asset { AssetId = 1, Quantity = 5 };
            var assignment = new AssetAssignment
            {
                AssignmentId = 1,
                AssetId = 1,
                Asset = asset,
                Quantity = 2,
                Status = "Assigned", 
                ReturnStatus = "Requested" 
            };

            await context.Assets.AddAsync(asset);
            await context.AssetAssignments.AddAsync(assignment);
            await context.SaveChangesAsync();

            var service = new AssetAssignmentService(context, _mapperMock.Object);
            var result = await service.ApproveReturnAsync(1);

            Assert.That(result, Is.EqualTo("Asset returned and inventory updated."));
            Assert.That(asset.Quantity, Is.EqualTo(7)); 
            Assert.That(assignment.Status, Is.EqualTo("Returned"));
            Assert.That(assignment.ReturnStatus, Is.EqualTo("Approved"));
            Assert.That(assignment.ReturnDate, Is.Not.Null);
        }
    }
}
