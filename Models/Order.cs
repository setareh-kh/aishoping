namespace Aishopping.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public  User? User { get; set; }
        public required int ProductId { get; set; }
        public  Product? Product { get; set; }
        public required int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

    }
}