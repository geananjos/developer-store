using MediatR;
using SalesSystem.Application.Carts.DTOs;
using SalesSystem.Application.Common;

namespace SalesSystem.Application.Carts.Queries.GetCarts
{
    public class GetCartsQuery : IRequest<PaginatedResult<CartDto>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? Order { get; set; }
    }
}
