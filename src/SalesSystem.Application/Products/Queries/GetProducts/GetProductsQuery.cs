using MediatR;
using SalesSystem.Application.Common;
using SalesSystem.Application.Products.DTOs;

namespace SalesSystem.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<PaginatedResult<ProductDto>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? Order { get; set; }
        public string? Category { get; set; }
    }
}
