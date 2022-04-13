using MediatR;

namespace CQRSApp.Cqrs.Handlers.CommandHadlers.Product
{
    public class CreateProductCommandRequest : IRequest<Guid>
    {
        public string? Code { get; set; }
        public decimal Price { get; set; }
    }
}
