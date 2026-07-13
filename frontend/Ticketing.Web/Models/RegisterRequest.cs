using System.ComponentModel.DataAnnotations;

namespace BlazorTicketingApp.Models
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "Nama wajib diisi.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email wajib diisi.")]
        [EmailAddress(ErrorMessage = "Format email tidak valid.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password wajib diisi.")]
        [MinLength(6, ErrorMessage = "Password minimal 6 karakter.")]
        public string Password { get; set; } = string.Empty;
    }
}