using AutoMapper;
using MediatR;
using SalesSystem.Application.Carts.DTOs;
using SalesSystem.Domain.Carts.Interfaces;

namespace SalesSystem.Application.Carts.Queries.GetCartById
{
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, CartDto?>
    {
        private readonly ICartRepository _repository;
        private readonly IMapper _mapper;

        public GetCartByIdQueryHandler(ICartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CartDto?> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _repository.GetByIdAsync(request.Id);
            return cart is null ? null : _mapper.Map<CartDto>(cart);
        }
    }
}
