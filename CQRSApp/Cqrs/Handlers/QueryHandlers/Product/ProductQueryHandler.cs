using CQRSApp.Context;
using CQRSApp.Cqrs.Handlers.QueryHandlers.Product;
using CQRSApp.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSApp.Cqrs
{
    public class ProductQueryHandler : IRequestHandler<GetProductsQuery, List<Models.Product>>
    {
        private readonly PostgreDbContext _context;

        public ProductQueryHandler()
        {
            _context = new PostgreDbContext();
        }

        public async Task<List<Models.Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            _context.Database.Migrate();

            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}
