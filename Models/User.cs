using System.ComponentModel.DataAnnotations;

namespace DotnetCoreWebApp.Models
{
    public class User
    {
        [Key]
        public int ? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required, MinLength(6)]
        public string? Password { get; set; }
    }
}
