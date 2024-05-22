using AutoMapper;
using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;
using Pronabec.Interface.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System;

namespace Pronabec.UseCases.Instituciones.Queries.GetAllInstitucionQuery
{
    public class GetAllInstitucionHandler : IRequestHandler<GetAllInstitucionQuery, BaseResponse<IEnumerable<InstitucionDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllInstitucionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<InstitucionDto>>> Handle(GetAllInstitucionQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<InstitucionDto>>();

            try
            {
                var instituciones = await _unitOfWork.Instituciones.GetAll();
                var institucionesDto = _mapper.Map<IEnumerable<InstitucionDto>>(instituciones);
                response.Data = institucionesDto;

                if (response.Data is not null)
                {
                    response.Success = true;
                    response.Message = "Consulta Exitosa";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;                
            }
            
            return response;
        }
    }
}
