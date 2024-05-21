using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;

namespace Pronabec.UseCases.Compromiso.Queries.GetAllCompromisoQuery
{
    public sealed record GetAllCompromisoQuery: IRequest<BaseResponse<IEnumerable<CompromisoDto>>>
    {
    }
}
