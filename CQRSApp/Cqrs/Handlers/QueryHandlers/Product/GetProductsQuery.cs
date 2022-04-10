using MediatR;

namespace CQRSApp.Cqrs.Handlers.QueryHandlers.Product
{
    public class GetProductsQuery : IRequest<List<Models.Product>>
    {
    }
}
