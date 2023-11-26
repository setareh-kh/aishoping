using System.ComponentModel.DataAnnotations;

namespace Aishopping.DTos.Requests
{
    public class UpdateOrder
    {
        [Required]
        public required int Quantity { get; set; }
    }
}