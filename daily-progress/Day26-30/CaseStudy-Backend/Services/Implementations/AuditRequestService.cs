using AssetManagement.Context;
using AssetManagement.DTOs.Audit;
using AssetManagement.Models;
using AssetManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Services.Implementations
{
    public class AuditRequestService : IAuditRequestService
    {
        private readonly ApplicationDbContext _context;

        public AuditRequestService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAuditRequestAsync(int assignmentId)
        {
            try
            {
                var assignment = await _context.AssetAssignments
                    .Include(a => a.Asset)
                    .Include(a => a.User)
                    .FirstOrDefaultAsync(a => a.AssignmentId == assignmentId && !a.IsReturned);

                if (assignment == null)
                    return false;

                var alreadyRequested = await _context.AssetAudits.AnyAsync(a =>
                    a.UserId == assignment.UserId &&
                    a.AssetId == assignment.AssetId &&
                    a.Status.ToLower() == "pending");

                if (alreadyRequested)
                    return false; 

                var audit = new AssetAudit
                {
                    UserId = assignment.UserId,
                    AssetId = assignment.AssetId,
                    AuditRequestDate = DateTime.Now,
                    Status = "Pending",
                    Remarks = string.Empty
                };

                _context.AssetAudits.Add(audit);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<AssetAudit>> GetMyAuditRequestsAsync(int userId)
        {
            try
            {
                return await _context.AssetAudits
                    .Include(a => a.Asset)
                    .Where(a => a.UserId == userId)
                    .OrderByDescending(a => a.AuditRequestDate)
                    .ToListAsync();
            }
            catch (Exception)
            {
                return new List<AssetAudit>();
            }
        }

        public async Task<bool> RespondToAuditAsync(AuditResponseDto dto, int userId)
        {
            try
            {
                var audit = await _context.AssetAudits
                    .FirstOrDefaultAsync(a => a.AuditId == dto.AuditId && a.UserId == userId);

                if (audit == null || audit.Status.ToLower() != "pending")
                    return false;

                audit.Status = dto.Status.ToLower();
                audit.Remarks = dto.Remarks ?? string.Empty;
                audit.AuditResponseDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }        
        public async Task<List<AssetAudit>> GetAllAuditRequestsAsync()
        {
            try
            {
                return await _context.AssetAudits
                    .Include(a => a.User)
                    .Include(a => a.Asset)
                        .ThenInclude(asset => asset.AssetCategory)
                    .OrderByDescending(a => a.AuditRequestDate)
                    .ToListAsync();
            }
            catch (Exception)
            {
                return new List<AssetAudit>();
            }
        }
    }
}
