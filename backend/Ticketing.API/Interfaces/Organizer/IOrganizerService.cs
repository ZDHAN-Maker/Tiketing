using Ticketing.API.DTOs;

namespace Ticketing.API.Interfaces
{
    public interface IOrganizerService
    {
        Task<IEnumerable<OrganizerResponseDto>> GetAllOrganizersAsync();
        Task<OrganizerResponseDto?> GetOrganizerByIdAsync(long id);
        Task<OrganizerResponseDto> CreateOrganizerAsync(CreateOrganizerDto dto);
        Task<bool> UpdateOrganizerAsync(long id, UpdateOrganizerDto dto);
        Task<bool> VerifyOrganizerAsync(long id, bool isVerified);
        
        Task<IEnumerable<StaffResponseDto>> GetStaffsByOrganizerIdAsync(long organizerId);
        Task<StaffResponseDto?> AddStaffAsync(long organizerId, AddStaffDto dto);
        Task<bool> RemoveStaffAsync(long organizerId, long staffId);
    }
}