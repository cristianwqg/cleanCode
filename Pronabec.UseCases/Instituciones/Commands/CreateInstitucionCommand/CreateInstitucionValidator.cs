using FluentValidation;

namespace Pronabec.UseCases.Instituciones.Commands.CreateInstitucionCommand
{
    public class CreateInstitucionValidator : AbstractValidator<CreateInstitucionCommand>
    {
        public CreateInstitucionValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Nombre).NotEmpty().NotNull().MinimumLength(5).MaximumLength(200);
        }
    }
}
