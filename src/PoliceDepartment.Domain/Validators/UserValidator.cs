using FluentValidation;
using PoliceDepartment.Domain.Entities;

namespace PoliceDepartment.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleSet("Authenticate", () =>
            {
                RuleFor(x => x.Username)
                        .NotEmpty()
                        .NotNull()
                        .WithMessage("Campo 'Username' deve ser preenchido");

                RuleFor(x => x.Password)
                        .NotEmpty()
                        .NotNull()
                        .WithMessage("Campo 'Password' deve ser preenchido");

            });
        }
    }
}
