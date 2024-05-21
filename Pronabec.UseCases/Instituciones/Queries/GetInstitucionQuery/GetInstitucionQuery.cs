using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;

namespace Pronabec.UseCases.Instituciones.Queries.GetInstitucionQuery
{
    public sealed record GetInstitucionQuery : IRequest<BaseResponse<InstitucionDto>>
    {
        public int Id { get; set; }
    }
}
