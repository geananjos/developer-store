using FluentValidation;
using SalesSystem.Application.Users.Commands.UpdateUser;
using SalesSystem.Domain.Users.Enums;

namespace SalesSystem.Application.Users.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Email)
                .NotEmpty().EmailAddress();

            RuleFor(x => x.Username)
                .NotEmpty().MaximumLength(50);

            RuleFor(x => x.Password)
                .NotEmpty().MinimumLength(6);

            RuleFor(x => x.Phone)
                .MaximumLength(20);

            RuleFor(x => x.Status)
                .NotEmpty().IsEnumName(typeof(UserStatus), false);

            RuleFor(x => x.Role)
                .NotEmpty().IsEnumName(typeof(UserRole), false);

            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name.Firstname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Name.Lastname).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.Address.City).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address.Street).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address.Number).GreaterThan(0);
            RuleFor(x => x.Address.Zipcode).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Address.Geolocation).NotNull();
            RuleFor(x => x.Address.Geolocation.Lat).NotEmpty();
            RuleFor(x => x.Address.Geolocation.Long).NotEmpty();
        }
    }
}
