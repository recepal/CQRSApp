namespace CQRSApp.Models
{
    public class Product : BaseEntity
    {
        public string? Code { get; set; }
        public decimal Price { get; set; }
    }
}
