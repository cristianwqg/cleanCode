using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronabec.UseCases.Personas.Queries.GetPersonaQuery
{
    public class GetPersonaValidator : AbstractValidator<GetPersonaQuery>
    {
        public GetPersonaValidator() { 
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
