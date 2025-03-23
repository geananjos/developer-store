using MediatR;
using SalesSystem.Domain.Carts.Interfaces;

namespace SalesSystem.Application.Carts.Commands.DeleteCart
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, bool>
    {
        private readonly ICartRepository _repository;

        public DeleteCartCommandHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _repository.GetByIdAsync(request.Id);
            if (cart is null) return false;

            await _repository.DeleteAsync(cart);
            return true;
        }
    }
}
