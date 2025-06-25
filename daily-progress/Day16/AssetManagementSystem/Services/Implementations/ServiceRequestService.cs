using AssetManagementSystem.Context;
using AssetManagementSystem.DTOs.ServiceRequest;
using AssetManagementSystem.Models;
using AssetManagementSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Services.Implementations
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly AssetDbContext _context;
        private readonly IMapper _mapper;

        public ServiceRequestService(AssetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadServiceRequestDTO>> GetAllAsync()
        {
            var requests = await _context.ServiceRequests
                .Include(r => r.Asset)
                .Include(r => r.Employee)
                .ToListAsync();

            return _mapper.Map<List<ReadServiceRequestDTO>>(requests);
        }

        public async Task<ReadServiceRequestDTO?> GetByIdAsync(int id)
        {
            var request = await _context.ServiceRequests
                .Include(r => r.Asset)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(r => r.RequestId == id);

            return request == null ? null : _mapper.Map<ReadServiceRequestDTO>(request);
        }
        public async Task<ReadServiceRequestDTO> CreateAsync(CreateServiceRequestDTO dto)
        {
            var asset = await _context.Assets.FindAsync(dto.AssetId);
            if (asset == null)
                throw new ArgumentException($"Asset with ID {dto.AssetId} does not exist.");

            var employee = await _context.Employees.FindAsync(dto.EmployeeId);
            if (employee == null)
                throw new ArgumentException($"Employee with ID {dto.EmployeeId} does not exist.");

            var request = _mapper.Map<ServiceRequest>(dto);
            request.Status = "Pending";
            request.RequestedDate = DateTime.UtcNow;

            _context.ServiceRequests.Add(request);
            await _context.SaveChangesAsync();

            var fullRequest = await _context.ServiceRequests
                .Include(r => r.Asset)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(r => r.RequestId == request.RequestId);

            return _mapper.Map<ReadServiceRequestDTO>(fullRequest!);
        }



        public async Task<bool> UpdateStatusAsync(int id, UpdateServiceRequestDTO dto)
        {
            var request = await _context.ServiceRequests.FindAsync(id);
            if (request == null)
                return false;

            request.Status = dto.Status;
            request.ResolvedDate = dto.Status == "Resolved" ? DateTime.UtcNow : null;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var request = await _context.ServiceRequests.FindAsync(id);
            if (request == null)
                return false;


            // Prevent deletion of already resolved requests
            if (request.Status == "Resolved")
                return false;

            _context.ServiceRequests.Remove(request);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
