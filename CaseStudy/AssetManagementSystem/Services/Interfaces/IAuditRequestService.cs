using AssetManagementSystem.DTOs.AuditRequest;

namespace AssetManagementSystem.Services.Interfaces
{
    public interface IAuditRequestService
    {
        Task<IEnumerable<ReadAuditRequestDTO>> GetAllAsync();
        Task<ReadAuditRequestDTO?> GetByIdAsync(int id);
        Task<ReadAuditRequestDTO> CreateAsync(CreateAuditRequestDTO dto);
        Task<bool> UpdateStatusAsync(int id, UpdateAuditRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
