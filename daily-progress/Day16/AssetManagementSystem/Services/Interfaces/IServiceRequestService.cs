using AssetManagementSystem.DTOs.ServiceRequest;

namespace AssetManagementSystem.Services.Interfaces
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ReadServiceRequestDTO>> GetAllAsync();
        Task<ReadServiceRequestDTO?> GetByIdAsync(int id);
        Task<ReadServiceRequestDTO> CreateAsync(CreateServiceRequestDTO dto);
        Task<bool> UpdateStatusAsync(int id, UpdateServiceRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

