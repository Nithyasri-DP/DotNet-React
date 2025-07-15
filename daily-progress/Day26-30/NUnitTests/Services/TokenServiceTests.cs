using AssetManagement.Models;
using AssetManagement.Services.Implementations;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTests.Services
{
    public class TokenServiceTests
    {
        private TokenService _tokenService;

        [SetUp]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string?> 
            {
                {"Jwt:Key", "ThisIsAStrongTestKey1234567890!@@@"},
                {"Jwt:Issuer", "TestIssuer"},
                {"Jwt:Audience", "TestAudience"},
                {"Jwt:DurationInMinutes", "30"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _tokenService = new TokenService(configuration);
        }

        [Test]
        public void GenerateToken_ShouldReturn_NonEmptyToken()
        {
            var user = new User
            {
                UserId = 1,
                Email = "admin@asset.com",
                FullName = "Admin User",
                Role = new Role { RoleName = "Admin" }
            };

            var token = _tokenService.GenerateToken(user);

            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);
        }
    }
}
