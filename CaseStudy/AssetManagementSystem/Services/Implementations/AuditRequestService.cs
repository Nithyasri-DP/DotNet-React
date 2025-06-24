using AssetManagementSystem.Context;
using AssetManagementSystem.DTOs.AuditRequest;
using AssetManagementSystem.Models;
using AssetManagementSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Services.Implementations
{
    public class AuditRequestService : IAuditRequestService
    {
        private readonly AssetDbContext _context;
        private readonly IMapper _mapper;

        public AuditRequestService(AssetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadAuditRequestDTO>> GetAllAsync()
        {
            var audits = await _context.AuditRequests
                .Include(a => a.Employee)
                .Include(a => a.Asset)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ReadAuditRequestDTO>>(audits);
        }

        public async Task<ReadAuditRequestDTO?> GetByIdAsync(int id)
        {
            var audit = await _context.AuditRequests
                .Include(a => a.Employee)
                .Include(a => a.Asset)
                .FirstOrDefaultAsync(a => a.AuditId == id);

            return audit == null ? null : _mapper.Map<ReadAuditRequestDTO>(audit);
        }

        public async Task<ReadAuditRequestDTO> CreateAsync(CreateAuditRequestDTO dto)
        {
            // Optional: validate existence of employee and asset
            var audit = _mapper.Map<AuditRequest>(dto);
            _context.AuditRequests.Add(audit);
            await _context.SaveChangesAsync();

            // Load navigation properties
            var created = await _context.AuditRequests
                .Include(a => a.Employee)
                .Include(a => a.Asset)
                .FirstOrDefaultAsync(a => a.AuditId == audit.AuditId);

            return _mapper.Map<ReadAuditRequestDTO>(created!);
        }

        public async Task<bool> UpdateStatusAsync(int id, UpdateAuditRequestDTO dto)
        {
            var audit = await _context.AuditRequests.FindAsync(id);
            if (audit == null)
                return false;

            audit.Status = dto.Status;
            audit.Remarks = dto.Remarks;
            audit.VerifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var audit = await _context.AuditRequests.FindAsync(id);
            if (audit == null)
                return false;

            _context.AuditRequests.Remove(audit);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
