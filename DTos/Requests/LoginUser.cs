using System.ComponentModel.DataAnnotations;

namespace DTos.Requests
{
    public class LoginUser
    {
        [Required]
        [MaxLength(255)]
        public required string FirstName { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(255)]
        public required string Password { get; set; }
    }
}