using MediatR;
using SalesSystem.Application.Carts.DTOs;

namespace SalesSystem.Application.Carts.Queries.GetCartById
{
    public class GetCartByIdQuery : IRequest<CartDto?>
    {
        public int Id { get; set; }
    }
}
