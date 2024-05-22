using AutoMapper;
using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;
using Pronabec.Interface.Persistence;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Pronabec.UseCases.Compromiso.Queries.GetAllCompromisoQuery
{
    public class GetAllCompromisoHandler : IRequestHandler<GetAllCompromisoQuery, BaseResponse<IEnumerable<CompromisoDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCompromisoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<CompromisoDto>>> Handle(GetAllCompromisoQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<CompromisoDto>>();

            try
            {
                var compromiso = await _unitOfWork.Compromiso.GetAll();
                var compromisoDto = _mapper.Map<IEnumerable<CompromisoDto>>(compromiso);
                response.Data = compromisoDto;

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
