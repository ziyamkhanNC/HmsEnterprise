using System.ComponentModel.DataAnnotations;

namespace Hms.server.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Patient"; // Also can be Admin,Doctor, Nurse, Patient
        public string? Specialization { get; set; } // For doctors only

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
