using System.ComponentModel.DataAnnotations;

namespace LabsApplicationAPI.ViewModels
{
    public class NewCustomerVM
    {
        [RegularExpression(@"[a-zA-Z\s]{2,32}")]
        public string Firstname { get; set; } = null!;

        [RegularExpression(@"[a-zA-Z\s]{2,32}")]
        public string Lastname { get; set; } = null!;

        [Range(minimum: 18, maximum: 120)]
        public int Age { get; set; }

        [RegularExpression(@"[a-zA-Z\s]{2,32}")]
        public string Country { get; set; } = null!;

        public bool? Gender { get; set; }

        [RegularExpression("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])")]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}
