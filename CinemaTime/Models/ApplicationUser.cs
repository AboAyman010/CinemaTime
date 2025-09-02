using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CinemaTime.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
    }
}
