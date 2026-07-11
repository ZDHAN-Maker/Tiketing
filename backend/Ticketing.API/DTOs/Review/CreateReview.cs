using System.ComponentModel.DataAnnotations;

namespace Ticketing.API.DTOs.Reviews
{
    public class CreateReviewDto
    {
        [Required]
        public long EventId { get; set; }
        
        // UserId DIHAPUS dari sini.

        [Required]
        [Range(1, 5, ErrorMessage = "Rating harus antara 1 sampai 5.")]
        public byte Rating { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }
    }
}