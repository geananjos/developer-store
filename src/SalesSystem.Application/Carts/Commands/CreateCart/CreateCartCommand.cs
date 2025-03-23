using MediatR;
using SalesSystem.Application.Carts.DTOs;

namespace SalesSystem.Application.Carts.Commands.CreateCart
{
    public class CreateCartCommand : IRequest<CartDto>
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public List<CreateCartItemDto> Products { get; set; } = new();
    }
}
