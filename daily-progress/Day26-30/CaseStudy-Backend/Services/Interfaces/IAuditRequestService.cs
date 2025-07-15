using AssetManagement.DTOs.Audit;
using AssetManagement.Models;

namespace AssetManagement.Services.Interfaces
{
    public interface IAuditRequestService
    {        
        Task<bool> CreateAuditRequestAsync(int assignmentId);
        Task<List<AssetAudit>> GetMyAuditRequestsAsync(int userId);
        Task<bool> RespondToAuditAsync(AuditResponseDto dto, int userId);
        Task<List<AssetAudit>> GetAllAuditRequestsAsync();
    }
}
