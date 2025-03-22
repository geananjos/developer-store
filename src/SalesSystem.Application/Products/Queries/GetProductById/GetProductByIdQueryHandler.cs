using AutoMapper;
using MediatR;
using SalesSystem.Application.Products.DTOs;
using SalesSystem.Domain.Products.Interfaces;

namespace SalesSystem.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            return product is null ? null : _mapper.Map<ProductDto>(product);
        }
    }
}
