namespace ManufacturerAPI.Models
{
    public class Blanket
    {
        public int Id { get; set; }
        public string BlanketName { get; set; }
        public string Material { get; set; }
        public int ProductionCapacity { get; set; }
        public int StockQuantity { get; set; }
    }
}
