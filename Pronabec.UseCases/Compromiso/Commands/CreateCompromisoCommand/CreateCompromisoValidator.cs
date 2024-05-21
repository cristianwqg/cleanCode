using FluentValidation;

namespace Pronabec.UseCases.Compromiso.Commands.CreateCompromisoCommand
{
    public class CreateCompromisoValidator : AbstractValidator<CreateCompromisoCommand>
    {
        public CreateCompromisoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Nombre).NotEmpty().NotNull().MinimumLength(5).MaximumLength(200);
        }
    }
}
