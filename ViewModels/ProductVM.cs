using System.ComponentModel.DataAnnotations;

namespace LabsApplicationAPI.ViewModels
{
    public class ProductVM
    {
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z]{2,32}")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        [Required]
        [RegularExpression("[a-zA-Z]{2,32}")]
        public string ProductType { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }
    }
}
