using System.ComponentModel.DataAnnotations;

namespace LabsApplicationAPI.ViewModels
{
    public class ProducerVM
    {
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Id { get; set; }


        [RegularExpression("[a-zA-Z]{2,32}")]
        public string Name { get; set; } = null!;


        [RegularExpression("[a-zA-Z]{2,32}")]
        public string? Country { get; set; }


        public string? Description { get; set; }
    }
}
