using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Application.Carts.Commands.CreateCart;
using SalesSystem.Application.Carts.Commands.DeleteCart;
using SalesSystem.Application.Carts.Commands.UpdateCart;
using SalesSystem.Application.Carts.DTOs;
using SalesSystem.Application.Carts.Queries.GetCartById;
using SalesSystem.Application.Carts.Queries.GetCarts;
using SalesSystem.Application.Common;

namespace SalesSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<CartDto>>> GetAll(
            [FromQuery(Name = "_page")] int page = 1,
            [FromQuery(Name = "_size")] int size = 10,
            [FromQuery(Name = "_order")] string? order = null)
        {
            var result = await _mediator.Send(new GetCartsQuery
            {
                Page = page,
                Size = size,
                Order = order
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetCartByIdQuery { Id = id });
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CartDto>> Create([FromBody] CreateCartCommand command)
        {
            var created = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CartDto>> Update(int id, [FromBody] UpdateCartCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID da rota não corresponde ao corpo da requisição.");

            var updated = await _mediator.Send(command);
            if (updated is null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteCartCommand { Id = id });
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
