using AutoMapper;
using MediatR;
using Pronabec.Dto;
using Pronabec.UseCases.Common.Bases;
using Pronabec.Interface.Persistence;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Pronabec.UseCases.Personas.Queries.GetAllPersonaQuery
{
    public class GetAllPersonaHandler : IRequestHandler<GetAllPersonaQuery, BaseResponse<IEnumerable<PersonaDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPersonaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<PersonaDto>>> Handle(GetAllPersonaQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<PersonaDto>>();

            try
            {
                var personas = await _unitOfWork.Personas.GetAll();
                var personasDto = _mapper.Map<IEnumerable<PersonaDto>>(personas);
                response.Data = personasDto;

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
