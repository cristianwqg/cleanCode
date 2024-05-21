using FluentValidation;

namespace Pronabec.UseCases.Personas.Commands.CreatePersonaCommand
{
    public class CreatePersonaValidator : AbstractValidator<CreatePersonaCommand>
    {
        public CreatePersonaValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Nombre).NotEmpty().NotNull().MinimumLength(5).MaximumLength(200);
        }
    }
}
