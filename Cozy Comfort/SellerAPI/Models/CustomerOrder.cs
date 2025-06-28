namespace SellerAPI.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string BlanketName { get; set; }
        public string Material { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
