using System.ComponentModel.DataAnnotations;

namespace LabsApplicationAPI.ViewModels
{
    public class NewOrderVM
    {
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int CustomerId { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int PaymentMethodId { get; set; }
    }
}
