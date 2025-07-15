using AssetManagement.Context;
using AssetManagement.DTOs.Service;
using AssetManagement.Models;
using AssetManagement.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace NUnitTests.Services
{
    public class ServiceRequestServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options = null!;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>() .UseInMemoryDatabase("ServiceRequestDb").Options;

            using var context = new ApplicationDbContext(_options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task CreateServiceRequestAsync_ShouldReturnTrue_WhenAssignmentExists()
        {
            using var context = new ApplicationDbContext(_options);

            var asset = new Asset { AssetId = 1, AssetName = "Laptop" };
            var assignment = new AssetAssignment
            {
                AssignmentId = 1,
                AssetId = 1,
                UserId = 2,
                Asset = asset,
                IsReturned = false
            };

            await context.Assets.AddAsync(asset);
            await context.AssetAssignments.AddAsync(assignment);
            await context.SaveChangesAsync();

            var service = new ServiceRequestService(context);

            var result = await service.CreateServiceRequestAsync(new ServiceRequestDto
            {
                AssignmentId = 1,
                Description = "Screen issue",
                IssueType = "Hardware"
            }, userId: 2);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task UpdateServiceRequestStatusAsync_ShouldReturnTrue_WhenRequestExists()
        {
            using var context = new ApplicationDbContext(_options);

            var request = new ServiceRequest
            {
                RequestId = 1,
                UserId = 2,
                AssetId = 1,
                Status = "pending",
                RequestDate = DateTime.UtcNow
            };

            await context.ServiceRequests.AddAsync(request);
            await context.SaveChangesAsync();

            var service = new ServiceRequestService(context);

            var result = await service.UpdateServiceRequestStatusAsync(new ServiceUpdateDto
            {
                ServiceRequestId = 1,
                Status = "Completed"
            });

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetMyServiceRequestsAsync_ShouldReturnRequests_ForGivenUserId()
        {
            using var context = new ApplicationDbContext(_options);
            await context.Assets.AddRangeAsync(
                new Asset { AssetId = 1, AssetName = "Laptop" },
                new Asset { AssetId = 2, AssetName = "Mouse" }
            );

            await context.SaveChangesAsync();
            var request1 = new ServiceRequest
            {
                RequestId = 1,
                UserId = 2,
                AssetId = 1,
                Description = "Battery issue",
                Status = "pending",
                RequestDate = DateTime.UtcNow
            };

            var request2 = new ServiceRequest
            {
                RequestId = 2,
                UserId = 2,
                AssetId = 2,
                Description = "Keyboard problem",
                Status = "completed",
                RequestDate = DateTime.UtcNow
            };

            var otherUserRequest = new ServiceRequest
            {
                RequestId = 3,
                UserId = 3,
                AssetId = 1,
                Description = "Unrelated",
                Status = "pending",
                RequestDate = DateTime.UtcNow
            };

            await context.ServiceRequests.AddRangeAsync(request1, request2, otherUserRequest);
            await context.SaveChangesAsync();

            var service = new ServiceRequestService(context);
            var result = await service.GetMyServiceRequestsAsync(userId: 2);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.TrueForAll(r => r.UserId == 2));
        }
    }
}
