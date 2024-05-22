using AutoMapper;
using MediatR;
using Pronabec.Dto;
using Pronabec.Interface.Persistence;
using Pronabec.UseCases.Common.Bases;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pronabec.UseCases.Compromiso.Queries.GetCompromisoQuery
{
    public class GetCompromisoHandler : IRequestHandler<GetCompromisoQuery, BaseResponse<CompromisoDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCompromisoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CompromisoDto>> Handle(GetCompromisoQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CompromisoDto>();
            try
            {
                var compromiso = await _unitOfWork.Compromiso.Get(request.Id);
                var compromisoDto = _mapper.Map<CompromisoDto>(compromiso);

                if (compromisoDto is not null)
                {
                    response.Success = true;
                    response.Data = compromisoDto;
                    response.Message = "Consulta Exitosa!!!";
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