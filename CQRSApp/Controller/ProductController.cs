using CQRSApp.Cqrs.Handlers.QueryHandlers.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetProductsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
