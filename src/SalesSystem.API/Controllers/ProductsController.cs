using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Application.Commands.CreateProduct;
using SalesSystem.Application.Common;
using SalesSystem.Application.DTOs;
using SalesSystem.Application.Queries.GetProducts;

namespace SalesSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetAll(
            [FromQuery(Name = "_page")] int page = 1,
            [FromQuery(Name = "_size")] int size = 10,
            [FromQuery(Name = "_order")] string? order = null,
            [FromQuery] string? category = null)
        {
            var result = await _mediator.Send(new GetProductsQuery
            {
                Page = page,
                Size = size,
                Order = order,
                Category = category
            });

            return Ok(result);
        }
    }
}
