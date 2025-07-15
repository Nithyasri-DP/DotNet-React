using AssetManagement.Context;
using AssetManagement.DTOs.Audit;
using AssetManagement.Models;
using AssetManagement.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NUnitTests.Services
{
    public class AuditRequestServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options = null!;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("AuditRequestDb").Options;

            using var context = new ApplicationDbContext(_options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task CreateAuditRequestAsync_ShouldReturnTrue_WhenAssignmentIsValid()
        {
            using var context = new ApplicationDbContext(_options);

            var asset = new Asset { AssetId = 1, AssetName = "Mouse" };
            var user = new User { UserId = 1, FullName = "Test User" };
            var assignment = new AssetAssignment
            {
                AssignmentId = 1,
                AssetId = 1,
                UserId = 1,
                IsReturned = false,
                Asset = asset,
                User = user
            };

            await context.Assets.AddAsync(asset);
            await context.Users.AddAsync(user);
            await context.AssetAssignments.AddAsync(assignment);
            await context.SaveChangesAsync();

            var service = new AuditRequestService(context);
            var result = await service.CreateAuditRequestAsync(1);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetMyAuditRequestsAsync_ShouldReturnOnlyUserSpecificRequests()
        {
            using var context = new ApplicationDbContext(_options);

            await context.Assets.AddAsync(new Asset { AssetId = 1, AssetName = "Monitor" });

            var audits = new List<AssetAudit>
            {
                new AssetAudit { AuditId = 1, UserId = 2, AssetId = 1, AuditRequestDate = DateTime.Now },
                new AssetAudit { AuditId = 2, UserId = 2, AssetId = 1, AuditRequestDate = DateTime.Now },
                new AssetAudit { AuditId = 3, UserId = 3, AssetId = 1, AuditRequestDate = DateTime.Now }
            };

            await context.AssetAudits.AddRangeAsync(audits);
            await context.SaveChangesAsync();

            var service = new AuditRequestService(context);
            var result = await service.GetMyAuditRequestsAsync(2);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task RespondToAuditAsync_ShouldUpdateStatusAndRemarks()
        {
            using var context = new ApplicationDbContext(_options);

            var audit = new AssetAudit
            {
                AuditId = 10,
                UserId = 5,
                AssetId = 1,
                Status = "Pending"
            };

            await context.AssetAudits.AddAsync(audit);
            await context.SaveChangesAsync();

            var service = new AuditRequestService(context);

            var response = new AuditResponseDto
            {
                AuditId = 10,
                Status = "Completed",
                Remarks = "Verified"
            };

            var result = await service.RespondToAuditAsync(response, userId: 5);
            Assert.IsTrue(result);
        }
    }
}
