using System.ComponentModel.DataAnnotations;

namespace LabsApplicationAPI.ViewModels
{
    public class NewProducerVM
    {
        [RegularExpression(@"[a-zA-Z\s]{2,32}")]
        public string Name { get; set; } = null!;


        [RegularExpression(@"[a-zA-Z\s]{2,32}")]
        public string? Country { get; set; }


        public string? Description { get; set; }
    }
}
