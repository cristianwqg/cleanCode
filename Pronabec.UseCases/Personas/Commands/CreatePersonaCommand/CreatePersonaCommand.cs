using MediatR;
using Pronabec.Dto;
using Pronabec.Dto.Enums;
using Pronabec.UseCases.Common.Bases;

namespace Pronabec.UseCases.Personas.Commands.CreatePersonaCommand
{    
    public record CreatePersonaCommand : IRequest<BaseResponse<PersonaDto>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Edad { get; set; }
        public DateTime FechaNac { get; set; }
        public EstadoDto Estado { get; set; }
    }
}