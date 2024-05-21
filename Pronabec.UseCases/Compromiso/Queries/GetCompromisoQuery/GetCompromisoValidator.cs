using FluentValidation;

namespace Pronabec.UseCases.Compromiso.Queries.GetCompromisoQuery
{
    public class GetCompromisoValidator : AbstractValidator<GetCompromisoQuery>
    {
        public GetCompromisoValidator() { 
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
