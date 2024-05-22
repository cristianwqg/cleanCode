using AutoMapper;
using MediatR;
using Pronabec.Dto;
using Pronabec.Interface.Persistence;
using Pronabec.UseCases.Common.Bases;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Pronabec.UseCases.Personas.Queries.GetPersonaQuery
{
    public class GetPersonaHandler : IRequestHandler<GetPersonaQuery, BaseResponse<PersonaDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PersonaDto>> Handle(GetPersonaQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PersonaDto>();
            try
            {
                var persona = await _unitOfWork.Personas.Get(request.Id);
                var personaDto = _mapper.Map<PersonaDto>(persona);

                if (personaDto is not null)
                {
                    response.Success = true;
                    response.Data = personaDto;
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