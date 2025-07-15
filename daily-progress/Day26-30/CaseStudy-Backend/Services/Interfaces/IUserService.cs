using AssetManagement.DTOs.User;

namespace AssetManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateEmployeeAsync(CreateEmployeeDto request);
        Task<UserDto?> GetOwnProfileAsync(int userId);
        Task<List<UserDto>> GetAllEmployeesAsync();
        Task<UserDto> UpdateEmployeeAsync(UpdateEmployeeDto updateDto);
        Task<string> SoftDeleteEmployeeAsync(int userId);
        Task<object?> GetEmployeeByIdAsync(int id);


    }
}
