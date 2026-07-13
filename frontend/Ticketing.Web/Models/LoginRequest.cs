using System.ComponentModel.DataAnnotations;

namespace BlazorTicketingApp.Models
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Email wajib diisi.")]
        [EmailAddress(ErrorMessage = "Format email tidak valid.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password wajib diisi.")]
        public string Password { get; set; } = string.Empty;
    }
}