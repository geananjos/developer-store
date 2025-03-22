using MediatR;
using SalesSystem.Application.DTOs;

namespace SalesSystem.Application.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public string Title { get; init; } = null!;
        public decimal Price { get; init; }
        public string Description { get; init; } = null!;
        public string Category { get; init; } = null!;
        public string Image { get; init; } = null!;
        public decimal RatingRate { get; init; }
        public int RatingCount { get; init; }
    }
}
