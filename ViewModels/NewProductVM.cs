using System.ComponentModel.DataAnnotations;

namespace LabsApplicationAPI.ViewModels
{
    public class NewProductVM
    {
        [Required]
        [RegularExpression(@"[a-zA-Z\s]{2,32}")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        [Required]
        [RegularExpression(@"[a-zA-Z\s]{2,32}")]
        public string ProductType { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }

        [Range(0, double.MaxValue)]
        public int Amount { get; set; } = 0;

        [Range(0, double.MaxValue)]
        public int ProducerId { get; set; }
    }
}
