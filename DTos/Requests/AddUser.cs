using System.ComponentModel.DataAnnotations;

namespace Aishopping.DTos.Requests
{
    public class AddUser
    {
        [Required]
        [MaxLength(255)]
        public required string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(255)]
        public required string Password { get; set; }
    }
}