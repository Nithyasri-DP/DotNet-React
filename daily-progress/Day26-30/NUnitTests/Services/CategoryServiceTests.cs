using AssetManagement.Context;
using AssetManagement.DTOs.Category;
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
    public class CategoryServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options = null!;
        private Mock<IMapper> _mapperMock = null!;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("CategoryDb").Options;

            using var context = new ApplicationDbContext(_options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public async Task CreateCategoryAsync_ShouldReturnSuccess_WhenCategoryIsUnique()
        {
            using var context = new ApplicationDbContext(_options);

            var dto = new CategoryCreateDto { CategoryName = "Electronics" };
            var entity = new AssetCategory { CategoryName = "Electronics" };

            _mapperMock.Setup(m => m.Map<AssetCategory>(dto)).Returns(entity);

            var service = new CategoryService(context, _mapperMock.Object);
            var result = await service.CreateCategoryAsync(dto);

            Assert.That(result, Is.EqualTo("Category created successfully."));
        }

        [Test]
        public async Task GetAllCategoriesAsync_ShouldReturnMappedList()
        {
            using var context = new ApplicationDbContext(_options);

            var categories = new List<AssetCategory>
            {
                new AssetCategory { CategoryId = 1, CategoryName = "Electronics", IsDeleted = false },
                new AssetCategory { CategoryId = 2, CategoryName = "Furniture", IsDeleted = false }
            };

            await context.AssetCategories.AddRangeAsync(categories);
            await context.SaveChangesAsync();

            var mapped = categories.Select(c => new CategoryCreateDto { CategoryName = c.CategoryName }).ToList();

            _mapperMock.Setup(m => m.Map<List<CategoryCreateDto>>(It.IsAny<List<AssetCategory>>())).Returns(mapped);

            var service = new CategoryService(context, _mapperMock.Object);
            var result = await service.GetAllCategoriesAsync();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task DeleteCategoryAsync_ShouldSoftDelete_WhenCategoryExists()
        {
            using var context = new ApplicationDbContext(_options);

            var category = new AssetCategory { CategoryId = 1, CategoryName = "Furniture", IsDeleted = false };
            await context.AssetCategories.AddAsync(category);
            await context.SaveChangesAsync();

            var service = new CategoryService(context, _mapperMock.Object);
            var result = await service.DeleteCategoryAsync(1);

            var deleted = await context.AssetCategories.FindAsync(1);

            Assert.That(result, Is.EqualTo("Category deleted successfully."));
            Assert.That(deleted?.IsDeleted, Is.True);
        }
    }
}
