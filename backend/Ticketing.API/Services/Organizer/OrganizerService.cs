using Microsoft.EntityFrameworkCore;
using Ticketing.API.Data;
using Ticketing.API.DTOs;
using Ticketing.API.Entities;
using Ticketing.API.Interfaces;

namespace Ticketing.API.Services
{
    public class OrganizerService : IOrganizerService
    {
        private readonly TicketingDbContext _context;

        public OrganizerService(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrganizerResponseDto>> GetAllOrganizersAsync()
        {
            return await _context.Organizers
                .Select(o => new OrganizerResponseDto
                {
                    Id = o.Id,
                    OwnerId = o.OwnerId,
                    Name = o.Name,
                    Description = o.Description,
                    LogoUrl = o.LogoUrl,
                    IsVerified = o.IsVerified,
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt
                }).ToListAsync();
        }

        public async Task<OrganizerResponseDto?> GetOrganizerByIdAsync(long id)
        {
            var o = await _context.Organizers.FindAsync(id);
            if (o == null) return null;
            return new OrganizerResponseDto { Id = o.Id, OwnerId = o.OwnerId, Name = o.Name, Description = o.Description, LogoUrl = o.LogoUrl, IsVerified = o.IsVerified, CreatedAt = o.CreatedAt, UpdatedAt = o.UpdatedAt };
        }

        public async Task<OrganizerResponseDto> CreateOrganizerAsync(CreateOrganizerDto dto)
        {
            var organizer = new Organizer { OwnerId = dto.OwnerId, Name = dto.Name, Description = dto.Description, LogoUrl = dto.LogoUrl };
            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync();

            return new OrganizerResponseDto { Id = organizer.Id, OwnerId = organizer.OwnerId, Name = organizer.Name, Description = organizer.Description, LogoUrl = organizer.LogoUrl, IsVerified = organizer.IsVerified, CreatedAt = organizer.CreatedAt, UpdatedAt = organizer.UpdatedAt };
        }

        public async Task<bool> UpdateOrganizerAsync(long id, UpdateOrganizerDto dto)
        {
            var o = await _context.Organizers.FindAsync(id);
            if (o == null) return false;

            o.Name = dto.Name;
            o.Description = dto.Description;
            o.LogoUrl = dto.LogoUrl;
            o.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerifyOrganizerAsync(long id, bool isVerified)
        {
            var o = await _context.Organizers.FindAsync(id);
            if (o == null) return false;

            o.IsVerified = isVerified;
            o.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StaffResponseDto>> GetStaffsByOrganizerIdAsync(long organizerId)
        {
            return await _context.OrganizerStaffs
                .Where(s => s.OrganizerId == organizerId)
                .Select(s => new StaffResponseDto { Id = s.Id, OrganizerId = s.OrganizerId, UserId = s.UserId, Position = s.Position, CreatedAt = s.CreatedAt })
                .ToListAsync();
        }

        public async Task<StaffResponseDto?> AddStaffAsync(long organizerId, AddStaffDto dto)
        {
            var organizerExists = await _context.Organizers.AnyAsync(o => o.Id == organizerId);
            if (!organizerExists) return null;

            // Cek duplikasi staff
            var alreadyStaff = await _context.OrganizerStaffs.AnyAsync(s => s.OrganizerId == organizerId && s.UserId == dto.UserId);
            if (alreadyStaff) return null;

            var staff = new OrganizerStaff { OrganizerId = organizerId, UserId = dto.UserId, Position = dto.Position };
            _context.OrganizerStaffs.Add(staff);
            await _context.SaveChangesAsync();

            return new StaffResponseDto { Id = staff.Id, OrganizerId = staff.OrganizerId, UserId = staff.UserId, Position = staff.Position, CreatedAt = staff.CreatedAt };
        }

        public async Task<bool> RemoveStaffAsync(long organizerId, long staffId)
        {
            var staff = await _context.OrganizerStaffs.FirstOrDefaultAsync(s => s.Id == staffId && s.OrganizerId == organizerId);
            if (staff == null) return false;

            _context.OrganizerStaffs.Remove(staff);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}