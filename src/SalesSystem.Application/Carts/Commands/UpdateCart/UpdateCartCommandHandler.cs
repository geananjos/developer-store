using AutoMapper;
using MediatR;
using SalesSystem.Application.Carts.DTOs;
using SalesSystem.Domain.Carts.Interfaces;
using SalesSystem.Domain.Carts.ValueObjects;

namespace SalesSystem.Application.Carts.Commands.UpdateCart
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, CartDto?>
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCartCommandHandler(ICartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CartDto?> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _repository.GetByIdAsync(request.Id);
            if (cart is null) return null;

            var utcDate = DateTime.SpecifyKind(request.Date, DateTimeKind.Utc);
            var items = request.Products.Select(p => (p.ProductId, p.Quantity)).ToList();

            cart.Update(request.UserId, utcDate, items);
            await _repository.UpdateAsync(cart);

            return _mapper.Map<CartDto>(cart);
        }
    }
}
