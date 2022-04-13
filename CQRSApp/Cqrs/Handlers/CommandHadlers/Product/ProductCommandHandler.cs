using CQRSApp.Context;
using CQRSApp.Cqrs.Handlers.CommandHadlers.Product;
using MediatR;

namespace CQRSApp.Cqrs.Handlers.CommandHadlers
{
    public class ProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Guid>
    {
        private readonly PostgreDbContext _context;
        public ProductCommandHandler(PostgreDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new CQRSApp.Models.Product().CreateProduct(request.Code, request.Price);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
