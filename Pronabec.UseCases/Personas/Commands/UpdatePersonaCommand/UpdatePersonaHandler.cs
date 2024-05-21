using AutoMapper;
using MediatR;
using Pronabec.Domain.Entities;
using Pronabec.Dto;
using Pronabec.Interface.Persistence;

namespace Pronabec.UseCases.Personas.Commands.UpdatePersonaCommand
{
    public class UpdatePersonaHandler : IRequestHandler<UpdatePersonaCommand, PersonaDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PersonaDto> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var persona = _mapper.Map<Persona>(request);
                _unitOfWork.Personas.Update(persona);

                persona = await _unitOfWork.Personas.Get(request.Id);
                var response = _mapper.Map<PersonaDto>(persona);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
