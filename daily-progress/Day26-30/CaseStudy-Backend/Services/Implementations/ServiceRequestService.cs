using AssetManagement.Context;
using AssetManagement.DTOs.Service;
using AssetManagement.Models;
using AssetManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Services.Implementations
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateServiceRequestAsync(ServiceRequestDto dto, int userId)
        {
            var assignment = await _context.AssetAssignments
                .Include(a => a.Asset)
                .FirstOrDefaultAsync(a => a.AssignmentId == dto.AssignmentId && a.UserId == userId && !a.IsReturned);

            if (assignment == null)
                return false;

            var existingRequest = await _context.ServiceRequests
                .AnyAsync(r => r.UserId == userId &&
                               r.AssetId == assignment.AssetId &&
                               r.Status != "Completed" &&
                               r.Status != "Rejected");

            if (existingRequest)
                throw new Exception("You already have an active service request for this asset.");

            string formattedIssueType = char.ToUpper(dto.IssueType[0]) + dto.IssueType.Substring(1).ToLower();

            var request = new ServiceRequest
            {
                UserId = userId,
                AssetId = assignment.AssetId,
                RequestDate = DateTime.Now,
                IssueType = formattedIssueType,
                Description = dto.Description,
                Status = "Pending"
            };

            _context.ServiceRequests.Add(request);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ServiceRequest>> GetMyServiceRequestsAsync(int userId)
        {
            return await _context.ServiceRequests
                .Include(sr => sr.Asset)
                .Where(sr => sr.UserId == userId)
                .OrderByDescending(sr => sr.RequestDate)
                .ToListAsync();
        }
        public async Task<List<ServiceRequest>> GetAllServiceRequestsAsync()
        {
            return await _context.ServiceRequests
                .Include(sr => sr.User)
                .Include(sr => sr.Asset)
                .OrderByDescending(sr => sr.RequestDate)
                .ToListAsync();
        }

        public async Task<bool> UpdateServiceRequestStatusAsync(ServiceUpdateDto dto)
        {
            var request = await _context.ServiceRequests.FindAsync(dto.ServiceRequestId);

            if (request == null)
                return false;
            request.Status = char.ToUpper(dto.Status[0]) + dto.Status.Substring(1).ToLower();

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
