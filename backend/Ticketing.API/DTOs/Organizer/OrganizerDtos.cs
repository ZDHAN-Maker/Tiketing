namespace Ticketing.API.DTOs
{
    public class CreateOrganizerDto
    {
        public long OwnerId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
    }

    public class UpdateOrganizerDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
    }

    public class VerifyOrganizerDto { public bool IsVerified { get; set; } }
    public class AddStaffDto { public long UserId { get; set; } public string? Position { get; set; } }

    public class OrganizerResponseDto
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class StaffResponseDto
    {
        public long Id { get; set; }
        public long OrganizerId { get; set; }
        public long UserId { get; set; }
        public string? Position { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}