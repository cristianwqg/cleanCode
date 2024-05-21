using FluentValidation;

namespace Pronabec.UseCases.Instituciones.Queries.GetInstitucionQuery
{
    public class GetInstitucionValidator : AbstractValidator<GetInstitucionQuery>
    {
        public GetInstitucionValidator() { 
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
