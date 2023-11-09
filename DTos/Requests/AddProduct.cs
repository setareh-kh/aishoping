using System.ComponentModel.DataAnnotations;

namespace Aishopping.DTos.Requests
{
    public class AddProduct
    {
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        [Required]
        public required decimal Price { get; set; }
    }
}