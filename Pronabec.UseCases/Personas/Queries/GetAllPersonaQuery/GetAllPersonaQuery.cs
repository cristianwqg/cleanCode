using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;

namespace Pronabec.UseCases.Personas.Queries.GetAllPersonaQuery
{
    public sealed record GetAllPersonaQuery: IRequest<BaseResponse<IEnumerable<PersonaDto>>>
    {
    }
}
