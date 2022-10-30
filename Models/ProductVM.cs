namespace LabsApplicationAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ProductType { get; set; } = null!;

        public decimal Price { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int Amount { get; set; }

        public int ProducerId { get; set; }
    }
}
