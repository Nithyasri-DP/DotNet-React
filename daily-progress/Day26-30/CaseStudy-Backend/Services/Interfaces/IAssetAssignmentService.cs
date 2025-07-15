using AssetManagement.DTOs.Asset;
using System.Threading.Tasks;

public interface IAssetAssignmentService
{
    Task<string> RequestAssetAsync(int userId, AssetRequestDto requestDto);
    Task<string> AssignAssetAsync(AssetAssignInputDto dto);    
    Task<string> RequestReturnAsync(int assignmentId, int employeeId);
    Task<string> ApproveReturnAsync(int assignmentId);
    Task<List<AssetAssignDto>> GetAllPendingRequestsAsync();
    Task<List<AssetAssignDto>> GetAllReturnRequestsAsync();
    Task<string> RejectRequestAsync(int assignmentId);
    Task<string> RejectReturnRequestAsync(int assignmentId);
    Task<List<AssetAssignDto>> GetAllAssignedAssetsAsync();
    Task<List<AssetAssignDto>> GetAllRejectedRequestsAsync();
    Task<List<AssetAssignDto>> GetMyAssetsAsync(int userId);

}
