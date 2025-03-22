using MediatR;
using SalesSystem.Application.Products.DTOs;

namespace SalesSystem.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDto?>
    {
        public int Id { get; set; }
        public string Title { get; init; } = null!;
        public decimal Price { get; init; }
        public string Description { get; init; } = null!;
        public string Category { get; init; } = null!;
        public string Image { get; init; } = null!;
        public decimal RatingRate { get; init; }
        public int RatingCount { get; init; }
    }
}
