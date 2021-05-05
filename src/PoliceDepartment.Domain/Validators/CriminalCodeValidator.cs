using FluentValidation;
using PoliceDepartment.Domain.Entities;

namespace PoliceDepartment.Domain.Validators
{
    public class CriminalCodeValidator : AbstractValidator<CriminalCode>
    {
        public CriminalCodeValidator()
        {
            RuleSet("CreateOrEdit", () =>
            {
                RuleFor(x => x.Name)
                        .NotEmpty()
                        .NotNull()
                        .WithMessage("Campo 'Name' deve ser preenchido")
                        .MaximumLength(120)
                        .WithMessage("Campo 'Name' deve conter no máximo 120 caracteres");

                RuleFor(x => x.Description)
                        .NotEmpty()
                        .NotNull()
                        .WithMessage("Campo 'Description' deve ser preenchido")
                        .MaximumLength(800)
                        .WithMessage("Campo 'Description' deve conter no máximo 800 caracteres");

                RuleFor(x => x.Penalty)
                        .GreaterThan(0)
                        .WithMessage("Campo 'Penalty' deve ser maior que 0");

                RuleFor(x=> x.PrisonTime)
                        .GreaterThan(0)
                        .WithMessage("Campo 'PrisonTime' deve ser maior que 0");

                RuleFor(x => x.Status)
                        .IsInEnum()
                        .WithMessage("Campo 'Status' deve ser preenchido");
            });
        }
    }
}
