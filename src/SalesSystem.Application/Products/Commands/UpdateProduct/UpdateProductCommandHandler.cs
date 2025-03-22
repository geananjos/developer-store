using AutoMapper;
using MediatR;
using SalesSystem.Application.Products.DTOs;
using SalesSystem.Domain.Products.Interfaces;
using SalesSystem.Domain.Products.ValueObjects;

namespace SalesSystem.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto?>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing is null) return null;

            existing.Update(
                request.Title,
                request.Price,
                request.Description,
                request.Category,
                request.Image,
                new Rating(request.RatingRate, request.RatingCount)
            );

            await _repository.UpdateAsync(existing);

            return _mapper.Map<ProductDto>(existing);
        }
    }
}
