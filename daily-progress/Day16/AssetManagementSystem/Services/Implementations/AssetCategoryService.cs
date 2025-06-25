using AssetManagementSystem.Context;
using AssetManagementSystem.DTOs.AssetCategory;
using AssetManagementSystem.Models;
using AssetManagementSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Services.Implementations
{
    public class AssetCategoryService : IAssetCategoryService
    {
        private readonly AssetDbContext _context;
        private readonly IMapper _mapper;

        public AssetCategoryService(AssetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReadAssetCategoryDTO>> GetAllAsync()
        {
            var categories = await _context.AssetCategories.ToListAsync();
            return _mapper.Map<List<ReadAssetCategoryDTO>>(categories);
        }

        public async Task<ReadAssetCategoryDTO?> GetByIdAsync(int id)
        {
            var category = await _context.AssetCategories.FindAsync(id);
            return category == null ? null : _mapper.Map<ReadAssetCategoryDTO>(category);
        }

        public async Task<List<ReadAssetCategoryDTO>> SearchByNameAsync(string? name)
        {
            var query = _context.AssetCategories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.CategoryName.Contains(name));
            }

            var result = await query.ToListAsync();
            return _mapper.Map<List<ReadAssetCategoryDTO>>(result);
        }

        public async Task<List<CategoryWithAvailabilityDTO>> GetCategoriesWithAvailabilityAsync()
        {
            return await _context.AssetCategories
                .Select(c => new CategoryWithAvailabilityDTO
                {
                    AssetCategoryId = c.AssetCategoryId,
                    CategoryName = c.CategoryName,
                    AvailableAssetCount = c.Assets!.Count(a => a.AssetStatus == "Available")
                })
                .ToListAsync();
        }

        public async Task<ReadAssetCategoryDTO> CreateAsync(CreateAssetCategoryDTO dto)
        {
            var category = _mapper.Map<AssetCategory>(dto);
            _context.AssetCategories.Add(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReadAssetCategoryDTO>(category);
        }

        public async Task<bool> UpdateAsync(int id, CreateAssetCategoryDTO dto)
        {
            var category = await _context.AssetCategories.FindAsync(id);
            if (category == null)
                return false;

            _mapper.Map(dto, category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.AssetCategories
                .Include(c => c.Assets)
                .FirstOrDefaultAsync(c => c.AssetCategoryId == id);

            if (category == null || (category.Assets != null && category.Assets.Any()))
                return false;

            _context.AssetCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
