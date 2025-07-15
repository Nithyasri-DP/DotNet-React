using AssetManagement.Context;
using AssetManagement.DTOs.Category;
using AssetManagement.Models;
using AssetManagement.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _context.AssetCategories
                                           .Where(c => !c.IsDeleted)
                                           .ToListAsync();

            var result = categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();

            return result;
        }
        public async Task<CategoryCreateDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.AssetCategories.Where(c => !c.IsDeleted).FirstOrDefaultAsync(c => c.CategoryId == id);
            return category == null ? null : _mapper.Map<CategoryCreateDto>(category);
        }

        public async Task<string> CreateCategoryAsync(CategoryCreateDto dto)
        {
            if (await _context.AssetCategories.AnyAsync(c => c.CategoryName == dto.CategoryName))
                throw new InvalidOperationException("Category name already exists.");

            var newCategory = _mapper.Map<AssetCategory>(dto);
            await _context.AssetCategories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return "Category created successfully.";
        }
        public async Task<string> UpdateCategoryAsync(int id, CategoryCreateDto dto)
        {
            var category = await _context.AssetCategories.FindAsync(id);
            if (category == null)
                throw new KeyNotFoundException("Category not found.");

            var duplicateExists = await _context.AssetCategories
                .AnyAsync(c => c.CategoryName == dto.CategoryName && c.CategoryId != id && !c.IsDeleted);

            if (duplicateExists)
                throw new InvalidOperationException("Another category with the same name already exists.");

            category.CategoryName = dto.CategoryName;
            _context.AssetCategories.Update(category);
            await _context.SaveChangesAsync();

            return "Category updated successfully.";
        }
        public async Task<string> DeleteCategoryAsync(int id)
        {
            var category = await _context.AssetCategories.FindAsync(id);
            if (category == null)
                throw new KeyNotFoundException("Category not found.");

            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return "Category deleted successfully.";
        }
    }
}
