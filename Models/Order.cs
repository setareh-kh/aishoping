namespace Aishopping.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public  required User User { get; set; }
        public required int ProductId { get; set; }
        public required Product Product { get; set; }
        public required int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

    }
}