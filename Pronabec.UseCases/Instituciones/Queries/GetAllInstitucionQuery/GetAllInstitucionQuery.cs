﻿using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;
using System.Collections.Generic;

namespace Pronabec.UseCases.Instituciones.Queries.GetAllInstitucionQuery
{
    public sealed record GetAllInstitucionQuery: IRequest<BaseResponse<IEnumerable<InstitucionDto>>>
    {
    }
}
