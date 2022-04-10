namespace CQRSApp.Models
{
    public class Order : BaseEntity
    {
        public string? Description { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
