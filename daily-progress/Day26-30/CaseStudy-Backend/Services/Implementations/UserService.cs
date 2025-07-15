using AssetManagement.Context;
using AssetManagement.DTOs.User;
using AssetManagement.Models;
using AssetManagement.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace AssetManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> CreateEmployeeAsync(CreateEmployeeDto request)
        {
            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
                throw new BadHttpRequestException("This email ID is already registered.");

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber) &&
                await _context.Users.AnyAsync(u => u.PhoneNumber == request.PhoneNumber))
                throw new BadHttpRequestException("This phone number is already registered.");

            var employee = _mapper.Map<User>(request);

            var normalizedRole = request.RoleName.Trim().ToLower();

            if (normalizedRole != "employee")
                throw new BadHttpRequestException("Only 'Employee' role is allowed for user creation.");

            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.RoleName.ToLower() == normalizedRole);

            if (role == null)
                throw new BadHttpRequestException("Role not found.");

            employee.RoleId = role.RoleId;
            employee.Password = BCrypt.Net.BCrypt.HashPassword(request.Password!);

            await _context.Users.AddAsync(employee);
            await _context.SaveChangesAsync();

            return "Employee created successfully.";
        }
        public async Task<UserDto?> GetOwnProfileAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Role) 
                .FirstOrDefaultAsync(u => u.UserId == userId);

            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAllEmployeesAsync()
        {
            var employees = await _context.Users
                .Include(u => u.Role) 
                .Where(u => !u.IsDeleted && u.Role.RoleName == "Employee")
                .ToListAsync();

            return _mapper.Map<List<UserDto>>(employees);
        }        
        public async Task<UserDto> UpdateEmployeeAsync(UpdateEmployeeDto updateDto)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserId == updateDto.UserId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            var normalizedRole = updateDto.RoleName.Trim().ToLower();

            if (normalizedRole != "employee")
                throw new BadHttpRequestException("Only 'Employee' role can be assigned.");

            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.RoleName.ToLower() == normalizedRole);

            if (role == null)
                throw new KeyNotFoundException("Role not found.");

            if (!string.IsNullOrWhiteSpace(updateDto.Email))
            {
                var existingEmail = await _context.Users
                    .AnyAsync(u => u.Email == updateDto.Email && u.UserId != updateDto.UserId && !u.IsDeleted);

                if (existingEmail)
                    throw new InvalidOperationException("This email is already registered to another employee.");
            }

            if (!string.IsNullOrWhiteSpace(updateDto.PhoneNumber))
            {
                var existingPhone = await _context.Users
                    .AnyAsync(u => u.PhoneNumber == updateDto.PhoneNumber && u.UserId != updateDto.UserId && !u.IsDeleted);

                if (existingPhone)
                    throw new InvalidOperationException("This phone number is already registered to another employee.");
            }

            _mapper.Map(updateDto, user);
            user.RoleId = role.RoleId;
            user.Role = role;

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }
        public async Task<object?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Users
                .Where(u => u.UserId == id && u.IsDeleted == false)
                .Select(u => new
                {
                    u.UserId,
                    u.FullName,
                    u.Email,
                    u.PhoneNumber,
                    u.Address,
                    Role = u.Role.RoleName
                })
                .FirstOrDefaultAsync();

            return employee;
        }
        public async Task<string> SoftDeleteEmployeeAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId && !u.IsDeleted);
            if (user == null)
                throw new KeyNotFoundException("User not found or already deleted.");

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return "Employee soft deleted successfully.";
        }
    }
}
