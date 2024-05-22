using MediatR;
using Pronabec.Dto;
using Pronabec.Dto.Enums;
using System;

namespace Pronabec.UseCases.Personas.Commands.UpdatePersonaCommand
{
    public sealed record UpdatePersonaCommand : IRequest<PersonaDto>
    {
        public int Id { get; set; }        
        public string Edad { get; set; }
        public DateTime FechaNac { get; set; }
        public EstadoDto Estado { get; set; }
    }
}