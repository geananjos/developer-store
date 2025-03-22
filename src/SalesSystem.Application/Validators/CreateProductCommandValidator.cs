using FluentValidation;
using SalesSystem.Application.Commands.CreateProduct;

namespace SalesSystem.Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
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
