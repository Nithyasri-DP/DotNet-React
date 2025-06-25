using AssetManagementSystem.Context;
using AssetManagementSystem.DTOs.Asset;
using AssetManagementSystem.Models;
using AssetManagementSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Services.Implementations
{
    public class AssetService : IAssetService
    {
        private readonly AssetDbContext _context;
        private readonly IMapper _mapper;

        public AssetService(AssetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Assign Asset
        public async Task<bool> AssignAssetAsync(int assetId, int employeeId)
        {
            var asset = await _context.Assets.FindAsync(assetId);
            var employee = await _context.Employees.FindAsync(employeeId);

            if (asset == null || employee == null)
                return false;

            if (asset.AssetStatus == "Assigned")
                return false;

            asset.EmployeeId = employeeId;
            asset.AssetStatus = "Assigned";
            asset.AllocationDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // Return Asset
        public async Task<bool> ReturnAssetAsync(int assetId)
        {
            var asset = await _context.Assets.FindAsync(assetId);
            if (asset == null || asset.AssetStatus != "Assigned")
                return false;

            asset.AssetStatus = "Available";
            asset.EmployeeId = null;
            asset.ReturnDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<AssetResponseDTO>> GetAllAssetsAsync(string? status, int? categoryId, string? userRole)
        {
            var query = _context.Assets
                .Include(a => a.AssetCategory)
                .Include(a => a.Employee)
                .AsQueryable();

            if (userRole == "Employee")
                query = query.Where(a => a.AssetStatus == "Available");
            else
            {
                if (!string.IsNullOrEmpty(status))
                    query = query.Where(a => a.AssetStatus == status);
                if (categoryId.HasValue)
                    query = query.Where(a => a.AssetCategoryId == categoryId.Value);
            }

            var assets = await query.ToListAsync();
            return _mapper.Map<IEnumerable<AssetResponseDTO>>(assets);
        }

        public async Task<IEnumerable<AssetAvailableDTO>> GetAvailableAssetsAsync()
        {
            var availableAssets = await _context.Assets
                .Include(a => a.AssetCategory)
                .Where(a => a.AssetStatus == "Available")
                .ToListAsync();

            return _mapper.Map<IEnumerable<AssetAvailableDTO>>(availableAssets);
        }

        public async Task<AssetResponseDTO?> GetAssetByIdAsync(int id)
        {
            var asset = await _context.Assets
                .Include(a => a.AssetCategory)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.AssetId == id);

            return asset == null ? null : _mapper.Map<AssetResponseDTO>(asset);
        }

        public async Task<AssetResponseDTO> CreateAssetAsync(CreateAssetDTO dto)
        {
            var asset = _mapper.Map<Asset>(dto);
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            var assetWithNav = await _context.Assets
                .Include(a => a.AssetCategory)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.AssetId == asset.AssetId);

            return _mapper.Map<AssetResponseDTO>(assetWithNav!);
        }

        public async Task<bool> UpdateAssetAsync(int id, UpdateAssetDTO dto)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
                return false;

            _mapper.Map(dto, asset);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAssetAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
                return false;

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
