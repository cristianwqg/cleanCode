using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronabec.UseCases.Personas.Queries.GetPersonaQuery
{
    public sealed record GetPersonaQuery : IRequest<BaseResponse<PersonaDto>>
    {
        public int Id { get; set; }
    }
}
