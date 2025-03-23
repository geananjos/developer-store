using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Application.Common;
using SalesSystem.Application.Users.Commands.CreateUser;
using SalesSystem.Application.Users.Commands.DeleteUser;
using SalesSystem.Application.Users.Commands.UpdateUser;
using SalesSystem.Application.Users.DTOs;

namespace SalesSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<UserDto>>> GetAll(
            [FromQuery(Name = "_page")] int page = 1,
            [FromQuery(Name = "_size")] int size = 10,
            [FromQuery(Name = "_order")] string? order = null)
        {
            var result = await _mediator.Send(new GetUsersQuery
            {
                Page = page,
                Size = size,
                Order = order
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { Id = id });
            if (result is null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserCommand command)
        {
            var created = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, [FromBody] UpdateUserCommand command)
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
            var deleted = await _mediator.Send(new DeleteUserCommand { Id = id });
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
