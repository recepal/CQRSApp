using CQRSApp.Cqrs.Handlers.CommandHadlers.Product;
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

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetProductsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("SaveProduct")]
        public async Task<ActionResult> SaveProducts(CreateProductCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(201, result);
        }
    }
}
