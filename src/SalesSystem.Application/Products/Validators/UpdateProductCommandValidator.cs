using FluentValidation;
using SalesSystem.Application.Products.Commands.UpdateProduct;

namespace SalesSystem.Application.Products.Validators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O ID do produto é inválido.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(100);

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("A categoria é obrigatória.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("A imagem é obrigatória.");

            RuleFor(x => x.RatingRate)
                .InclusiveBetween(0, 5).WithMessage("A nota deve estar entre 0 e 5.");

            RuleFor(x => x.RatingCount)
                .GreaterThanOrEqualTo(0);
        }
    }
}
