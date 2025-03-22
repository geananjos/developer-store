using MediatR;
using SalesSystem.Application.Products.DTOs;

namespace SalesSystem.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto?>
    {
        public int Id { get; set; }
    }
}
