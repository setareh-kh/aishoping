using System.ComponentModel.DataAnnotations;

namespace DTos.Requests
{
    public class AddOrder
    {
        [Required]
        public required int UserId { get; set; }
        [Required]
        public required int ProductId { get; set; }
        [Required]
        public required int Quantity { get; set; }
    }
}