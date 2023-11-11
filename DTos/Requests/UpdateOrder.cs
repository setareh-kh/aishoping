using System.ComponentModel.DataAnnotations;

namespace DTos.Requests
{
    public class UpdateOrder
    {
        [Required]
        public required int Quantity { get; set; }
    }
}