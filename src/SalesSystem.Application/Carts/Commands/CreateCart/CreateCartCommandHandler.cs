using AutoMapper;
using MediatR;
using SalesSystem.Application.Carts.DTOs;
using SalesSystem.Domain.Carts;
using SalesSystem.Domain.Carts.Interfaces;
using SalesSystem.Domain.Carts.ValueObjects;

namespace SalesSystem.Application.Carts.Commands.CreateCart
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, CartDto>
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;

        public CreateCartCommandHandler(ICartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CartDto> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var utcDate = DateTime.SpecifyKind(request.Date, DateTimeKind.Utc);
            var items = request.Products.Select(p => (p.ProductId, p.Quantity)).ToList();

            var cart = new Cart(request.UserId, utcDate, items);

            await _repository.AddAsync(cart);

            return _mapper.Map<CartDto>(cart);
        }
    }
}
