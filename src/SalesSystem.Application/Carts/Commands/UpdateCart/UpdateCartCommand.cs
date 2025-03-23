using MediatR;
using SalesSystem.Application.Carts.DTOs;

namespace SalesSystem.Application.Carts.Commands.UpdateCart
{
    public class UpdateCartCommand : IRequest<CartDto?>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public List<CreateCartItemDto> Products { get; set; } = new();
    }
}
