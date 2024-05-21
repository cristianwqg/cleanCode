using AutoMapper;
using MediatR;
using Pronabec.Dto;
using Pronabec.Interface.Persistence;
using Pronabec.UseCases.Common.Bases;

namespace Pronabec.UseCases.Instituciones.Queries.GetInstitucionQuery
{
    public class GetInstitucionHandler : IRequestHandler<GetInstitucionQuery, BaseResponse<InstitucionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInstitucionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<InstitucionDto>> Handle(GetInstitucionQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<InstitucionDto>();
            try
            {
                var institucion = await _unitOfWork.Instituciones.Get(request.Id);
                var institucionDto = _mapper.Map<InstitucionDto>(institucion);

                if (institucionDto is not null)
                {
                    response.Success = true;
                    response.Data = institucionDto;
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