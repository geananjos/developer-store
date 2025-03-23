using FluentValidation;
using SalesSystem.Application.Carts.Commands.CreateCart;

namespace SalesSystem.Application.Carts.Validators
{
    public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0);

            RuleFor(x => x.Date)
                .NotEmpty();

            RuleFor(x => x.Products)
                .NotEmpty().WithMessage("O carrinho precisa conter ao menos um produto.");

            RuleForEach(x => x.Products).ChildRules(product =>
            {
                product.RuleFor(p => p.ProductId)
                    .GreaterThan(0).WithMessage("ID do produto deve ser maior que zero.");

                product.RuleFor(p => p.Quantity)
                    .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.");
            });
        }
    }
}
