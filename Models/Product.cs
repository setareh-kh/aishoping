using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        [Required]
        public required decimal Price { get; set; }
        public List<Order>? Orders { get; set; }
    }
}

