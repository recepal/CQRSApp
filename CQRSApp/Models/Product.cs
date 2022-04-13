namespace CQRSApp.Models
{
    public class Product : BaseEntity
    {
        public string? Code { get;protected set; }
        public decimal Price { get;protected set; }

        #region actions
        public Product CreateProduct(string? code, decimal price)
        {
            Id = Guid.NewGuid();
            Code = code;
            Price = price;
            return this;
        }
        #endregion
    }
}
