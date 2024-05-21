using AutoMapper;
using FluentValidation;
using MediatR;
using Pronabec.Domain.Entities;
using Pronabec.Domain.Events;
using Pronabec.Dto;
using Pronabec.Interface.Infrastructure;
using Pronabec.Interface.Persistence;
using Pronabec.UseCases.Common.Bases;

namespace Pronabec.UseCases.Personas.Commands.CreatePersonaCommand
{
    public class CreatePersonaHandler : IRequestHandler<CreatePersonaCommand, BaseResponse<PersonaDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;

        public CreatePersonaHandler(IUnitOfWork unitOfWork, IMapper mapper, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        public async Task<BaseResponse<PersonaDto>> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PersonaDto>();
            try
            {
                var persona = _mapper.Map<Persona>(request);
                _unitOfWork.Personas.Create(persona);

                persona = await _unitOfWork.Personas.Get(persona.Id);


                var personaDto = _mapper.Map<PersonaDto>(persona);

                if (personaDto is not null)
                {
                    response.Success = true;
                    response.Data = personaDto;
                    response.Message = "Registro Exitoso!";

                    /* Publicamos el evento */
                    var personaCreatedEvent = _mapper.Map<PersonaCreatedEvent>(persona);
                    _eventBus.Publish(personaCreatedEvent);
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
