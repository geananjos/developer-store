using MediatR;

namespace SalesSystem.Application.Carts.Commands.DeleteCart
{
    public class DeleteCartCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
