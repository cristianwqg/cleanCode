using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Pronabec.UseCases.Personas.Queries.GetAllPersonaQuery
{
    public sealed record GetAllPersonaQuery: IRequest<BaseResponse<IEnumerable<PersonaDto>>>
    {
    }
}
