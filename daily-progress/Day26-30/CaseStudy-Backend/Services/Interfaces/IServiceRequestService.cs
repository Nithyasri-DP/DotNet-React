using AssetManagement.DTOs.Service;
using AssetManagement.Models;

namespace AssetManagement.Services.Interfaces
{
    public interface IServiceRequestService
    {
        Task<bool> CreateServiceRequestAsync(ServiceRequestDto dto, int userId);
        Task<List<ServiceRequest>> GetMyServiceRequestsAsync(int userId);
        Task<List<ServiceRequest>> GetAllServiceRequestsAsync();
        Task<bool> UpdateServiceRequestStatusAsync(ServiceUpdateDto dto);
    }
}
