using System.ComponentModel.DataAnnotations;

namespace Aishopping.Models
{
    public class User
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public  required string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(255)]
        public  required string  Password { get; set; }
        public List<Order>? Orders { get; set; }
    }
}