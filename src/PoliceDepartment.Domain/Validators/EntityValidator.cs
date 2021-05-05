using FluentValidation;
using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Repositories;

namespace PoliceDepartment.Domain.Validators
{
    public class EntityValidator : AbstractValidator<int>
    {
        public EntityValidator(IQueryableRepository<CriminalCode> criminalCodeRepository)
        {
            RuleSet("CriminalCodeExists", () =>
            {
                RuleFor(x => x)
                        .MustAsync(async (id, cancellationToken) =>
                        {
                            var entity = await criminalCodeRepository.GetAsync(id);
                            return entity != null;
                        })
                        .WithMessage(x => $"Criminal code of Id [{x}] does not exists");
            });
        }
    }
}
