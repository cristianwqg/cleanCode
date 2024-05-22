using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Pronabec.UseCases.Compromiso.Queries.GetAllCompromisoQuery
{
    public sealed record GetAllCompromisoQuery: IRequest<BaseResponse<IEnumerable<CompromisoDto>>>
    {
    }
}
