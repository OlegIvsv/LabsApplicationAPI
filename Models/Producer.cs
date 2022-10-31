namespace LabsApplicationAPI.Models
{
    public class Producer
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Country { get; set; }

        public string? Description { get; set; }
    }
}
