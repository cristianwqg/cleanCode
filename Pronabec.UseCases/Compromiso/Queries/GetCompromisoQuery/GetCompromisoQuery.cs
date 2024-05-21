using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;

namespace Pronabec.UseCases.Compromiso.Queries.GetCompromisoQuery
{
    public sealed record GetCompromisoQuery : IRequest<BaseResponse<CompromisoDto>>
    {
        public int Id { get; set; }
    }
}
