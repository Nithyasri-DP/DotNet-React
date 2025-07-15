using AssetManagement.Context;
using AssetManagement.DTOs.Asset;
using AssetManagement.Models;
using AssetManagement.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Services.Implementations
{
    public class AssetService : IAssetService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AssetService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateAssetAsync(AssetCreateDto assetDto)
        {
            bool nameExists = await _context.Assets
                .AnyAsync(a => !a.IsDeleted && a.AssetName.ToLower() == assetDto.AssetName.ToLower());

            if (nameExists)
                throw new InvalidOperationException("Asset with the same name already exists.");

            if (assetDto.ManufacturingDate.Year < 2000)
                throw new ArgumentException("Manufacturing date must be after the year 2000.");

            if (assetDto.ManufacturingDate > DateTime.UtcNow)
                throw new ArgumentException("Manufacturing date cannot be in the future.");

            if (assetDto.ExpiryDate <= DateTime.UtcNow)
                throw new ArgumentException("Expiry date must be a future date.");

            var asset = _mapper.Map<Asset>(assetDto);
            await _context.Assets.AddAsync(asset);
            await _context.SaveChangesAsync();
            return asset.AssetId;
        }

        public async Task<bool> UpdateAssetAsync(int assetId, AssetUpdateDto dto)
        {
            var asset = await _context.Assets.FirstOrDefaultAsync(a => a.AssetId == assetId && !a.IsDeleted);
            if (asset == null) return false;

            if (!string.IsNullOrWhiteSpace(dto.AssetName))
            {
                bool nameExists = await _context.Assets
                    .AnyAsync(a => a.AssetId != assetId && !a.IsDeleted && a.AssetName.ToLower() == dto.AssetName.ToLower());

                if (nameExists)
                    throw new InvalidOperationException("Another asset with the same name already exists.");

                asset.AssetName = dto.AssetName;
            }

            if (!string.IsNullOrWhiteSpace(dto.AssetModel))
                asset.AssetModel = dto.AssetModel;

            if (dto.CategoryId.HasValue)
                asset.CategoryId = dto.CategoryId.Value;

            if (dto.ManufacturingDate.HasValue)
            {
                if (dto.ManufacturingDate.Value.Year < 2000)
                    throw new ArgumentException("Manufacturing date must be after the year 2000.");

                if (dto.ManufacturingDate.Value > DateTime.UtcNow)
                    throw new ArgumentException("Manufacturing date cannot be in the future.");

                asset.ManufacturingDate = dto.ManufacturingDate.Value;
            }

            if (dto.ExpiryDate.HasValue)
            {
                if (dto.ExpiryDate.Value <= DateTime.UtcNow)
                    throw new ArgumentException("Expiry date must be a future date.");

                asset.ExpiryDate = dto.ExpiryDate.Value;
            }

            if (dto.AssetValue.HasValue)
                asset.AssetValue = dto.AssetValue.Value;

            if (dto.Quantity.HasValue)
                asset.Quantity = dto.Quantity.Value;

            if (!string.IsNullOrWhiteSpace(dto.ImageUrl))
                asset.ImageUrl = dto.ImageUrl;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AssetDetailDto>> GetAllAssetsAsync()
        {
            var assets = await _context.Assets
                .Where(a => !a.IsDeleted)
                .Include(a => a.AssetCategory)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AssetDetailDto>>(assets);
        }

        public async Task<AssetDetailDto?> GetAssetByIdAsync(int assetId)
        {
            var asset = await _context.Assets
                .Where(a => !a.IsDeleted)
                .Include(a => a.AssetCategory)
                .FirstOrDefaultAsync(a => a.AssetId == assetId);

            return asset is null ? null : _mapper.Map<AssetDetailDto>(asset);
        }

        public async Task<IEnumerable<AssetAvailableDto>> GetAvailableAssetsForEmployeeAsync()
        {
            var assets = await _context.Assets
                .Include(a => a.AssetCategory)
                .Where(a => !a.IsDeleted && a.Quantity > 0)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AssetAvailableDto>>(assets);
        }

        public async Task<bool> DeleteAssetAsync(int assetId)
        {
            var asset = await _context.Assets.FindAsync(assetId);
            if (asset == null || asset.IsDeleted) return false;

            asset.IsDeleted = true;
            asset.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<AssetAssignDto>> GetAssignedAssetsForEmployeeAsync(int userId)
        {
            var assignments = await _context.AssetAssignments
                .Include(a => a.Asset).ThenInclude(a => a.AssetCategory)
                .Include(a => a.User)
                .Where(a => a.UserId == userId && a.Status == "Assigned")
                .ToListAsync();

            return assignments.Select(a => new AssetAssignDto
            {
                AssignmentId = a.AssignmentId,
                UserId = a.UserId,
                UserName = a.User.FullName,
                AssetId = a.AssetId,
                AssetName = a.Asset.AssetName,
                AssetModel = a.Asset.AssetModel,
                CategoryName = a.Asset.AssetCategory.CategoryName,
                ImageUrl = a.Asset.ImageUrl,
                Quantity = a.Quantity,
                Status = a.Status,
                AssignedDate = a.AssignedDate,
                ReturnDate = a.ReturnDate
            }).ToList();
        }
    }
}
