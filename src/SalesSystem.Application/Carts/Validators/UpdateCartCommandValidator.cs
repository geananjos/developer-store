using FluentValidation;
using SalesSystem.Application.Carts.Commands.UpdateCart;

namespace SalesSystem.Application.Carts.Validators
{
    public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.UserId)
                .GreaterThan(0);

            RuleFor(x => x.Date)
                .NotEmpty();

            RuleFor(x => x.Products)
                .NotEmpty().WithMessage("O carrinho precisa conter ao menos um produto.");

            RuleForEach(x => x.Products).ChildRules(product =>
            {
                product.RuleFor(p => p.ProductId)
                    .GreaterThan(0);

                product.RuleFor(p => p.Quantity)
                    .GreaterThan(0);
            });
        }
    }
}
