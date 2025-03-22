using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Application.Common;
using SalesSystem.Application.Products.Commands.CreateProduct;
using SalesSystem.Application.Products.Commands.DeleteProduct;
using SalesSystem.Application.Products.Commands.UpdateProduct;
using SalesSystem.Application.Products.DTOs;
using SalesSystem.Application.Products.Queries.GetProductById;
using SalesSystem.Application.Products.Queries.GetProducts;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
            if (product is null) return NotFound();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(int id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id) return BadRequest("ID da rota não corresponde ao do corpo da requisição");

            var updated = await _mediator.Send(command);
            if (updated is null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteProductCommand { Id = id });
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
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
