using AutoMapper;
using MediatR;
using SalesSystem.Application.Products.DTOs;
using SalesSystem.Domain.Products;
using SalesSystem.Domain.Products.Interfaces;

namespace SalesSystem.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            await _repository.AddAsync(product);

            return _mapper.Map<ProductDto>(product);
        }
    }
}
