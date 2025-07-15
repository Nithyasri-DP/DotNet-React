using AssetManagement.Context;
using AssetManagement.DTOs.Asset;
using AssetManagement.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

public class AssetAssignmentService : IAssetAssignmentService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public AssetAssignmentService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<string> RequestAssetAsync(int userId, AssetRequestDto requestDto)
    {
        var asset = await _context.Assets.FirstOrDefaultAsync(a => a.AssetId == requestDto.AssetId && !a.IsDeleted);
        if (asset == null)
            throw new Exception("Asset not found.");

        var existingPendingRequest = await _context.AssetAssignments
            .AnyAsync(a => a.UserId == userId && a.AssetId == requestDto.AssetId && a.Status == "Requested");

        if (existingPendingRequest)
            throw new Exception("You have already requested this asset and it's pending approval.");

        var alreadyAssigned = await _context.AssetAssignments
            .AnyAsync(a => a.UserId == userId && a.AssetId == requestDto.AssetId && a.Status == "Assigned");

        if (alreadyAssigned)
            throw new Exception("You already have this asset assigned.");

        if (requestDto.Quantity <= 0)
            throw new Exception("Quantity must be greater than zero.");

        var assignment = new AssetAssignment
        {
            UserId = userId,
            AssetId = requestDto.AssetId,
            Quantity = requestDto.Quantity,
            Status = "Requested",
            AssignedDate = DateTime.Now
        };

        await _context.AssetAssignments.AddAsync(assignment);
        await _context.SaveChangesAsync();

        return "Asset request submitted.";
    }

    public async Task<string> AssignAssetAsync(AssetAssignInputDto dto)
    {
        var assignment = await _context.AssetAssignments
            .Include(a => a.Asset)
            .FirstOrDefaultAsync(a => a.AssignmentId == dto.AssignmentId && a.Status == "Requested" && !a.IsDeleted);

        if (assignment == null)
            throw new KeyNotFoundException("Assignment request not found.");

        if (assignment.Asset.Quantity < assignment.Quantity)
            throw new InvalidOperationException("Not enough assets available to assign.");

        assignment.Status = "Assigned";
        assignment.AssignedDate = dto.AssignedDate;
        assignment.Asset.Quantity -= assignment.Quantity;

        await _context.SaveChangesAsync();

        return "Asset assigned successfully.";
    }

    public async Task<string> RequestReturnAsync(int assignmentId, int employeeId)
    {
        var assignment = await _context.AssetAssignments
            .FirstOrDefaultAsync(a => a.AssignmentId == assignmentId && a.UserId == employeeId && a.Status == "Assigned");

        if (assignment == null)
            throw new BadHttpRequestException("Assignment not found or not approved.");

        if (assignment.ReturnStatus == "Requested")
            throw new BadHttpRequestException("Return request already submitted.");

        assignment.ReturnStatus = "Requested";
        _context.AssetAssignments.Update(assignment);
        await _context.SaveChangesAsync();

        return "Return request submitted successfully.";
    }
    public async Task<string> ApproveReturnAsync(int assignmentId)
    {
        var assignment = await _context.AssetAssignments
            .Include(a => a.Asset)
            .FirstOrDefaultAsync(a =>
                a.AssignmentId == assignmentId &&
                a.Status == "Assigned" &&
                a.ReturnStatus == "Requested");

        if (assignment == null)
            throw new InvalidOperationException("No return request found.");

        assignment.Status = "Returned";
        assignment.ReturnStatus = "Approved";
        assignment.ReturnDate = DateTime.Now;
        assignment.Asset.Quantity += assignment.Quantity;

        await _context.SaveChangesAsync();
        return "Asset returned and inventory updated.";
    }

    public async Task<List<AssetAssignDto>> GetAllReturnRequestsAsync()
    {
        var returns = await _context.AssetAssignments
            .Include(a => a.User)
            .Include(a => a.Asset)
            .Where(a => a.Status == "Assigned" && a.ReturnStatus == "Requested" && !a.IsDeleted)
            .ToListAsync();

        return _mapper.Map<List<AssetAssignDto>>(returns);
    }
    public async Task<List<AssetAssignDto>> GetAllPendingRequestsAsync()
    {
        var pendingRequests = await _context.AssetAssignments
            .Include(a => a.Asset)
            .Include(a => a.User)
            .Where(a => a.Status == "Requested" && !a.IsDeleted)
            .ToListAsync();

        return _mapper.Map<List<AssetAssignDto>>(pendingRequests);
    }
    public async Task<string> RejectRequestAsync(int assignmentId)
    {
        var assignment = await _context.AssetAssignments
            .FirstOrDefaultAsync(a => a.AssignmentId == assignmentId && !a.IsDeleted);

        if (assignment == null || assignment.Status != "Requested")
            throw new InvalidOperationException("Request not found or not in a state to reject.");

        assignment.Status = "Rejected";
        await _context.SaveChangesAsync();

        return "Request rejected successfully.";
    }
    public async Task<string> RejectReturnRequestAsync(int assignmentId)
    {
        var assignment = await _context.AssetAssignments
            .FirstOrDefaultAsync(a => a.AssignmentId == assignmentId && a.ReturnStatus == "Requested");

        if (assignment == null)
            throw new InvalidOperationException("No return request found or already processed.");

        assignment.ReturnStatus = "Rejected";
        await _context.SaveChangesAsync();

        return "Return request rejected.";
    }
    public async Task<List<AssetAssignDto>> GetAllAssignedAssetsAsync()
    {
        var assignments = await _context.AssetAssignments
            .Include(a => a.Asset).ThenInclude(a => a.AssetCategory)
            .Include(a => a.User)
            .Where(a => (a.Status == "Assigned" || a.Status == "Returned" || a.Status == "Rejected") && !a.Asset.IsDeleted)
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
    public async Task<List<AssetAssignDto>> GetAllRejectedRequestsAsync()
    {
        var rejected = await _context.AssetAssignments
            .Include(a => a.User)
            .Include(a => a.Asset)
            .Where(a => a.Status == "Rejected" && !a.IsDeleted)
            .ToListAsync();

        return _mapper.Map<List<AssetAssignDto>>(rejected);
    }
    public async Task<List<AssetAssignDto>> GetMyAssetsAsync(int userId)
    {
        var assignments = await _context.AssetAssignments
            .Include(a => a.Asset).ThenInclude(a => a.AssetCategory)
            .Where(a =>
                a.UserId == userId &&
                (a.Status == "Assigned" || a.Status == "Returned" || a.Status == "Rejected") &&
                !a.Asset.IsDeleted)
            .ToListAsync();

        return assignments.Select(a => new AssetAssignDto
        {
            AssignmentId = a.AssignmentId,
            UserId = a.UserId,
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
