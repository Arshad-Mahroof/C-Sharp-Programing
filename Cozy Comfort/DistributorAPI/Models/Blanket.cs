namespace DistributorAPI.Models
{
    public class Blanket
    {
        public int Id { get; set; }
        public string blanketName { get; set; }
        public string Material { get; set; }
        public int StockQuantity { get; set; }
        public int ProductionCapacity { get; set; }
    }
}
