namespace LabsApplicationAPI.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public int CustomerId { get; set; }

        public int PaymentMethodId { get; set; }
    }
}
