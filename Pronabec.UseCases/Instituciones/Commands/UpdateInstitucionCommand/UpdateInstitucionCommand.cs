using MediatR;
using Pronabec.Dto;
using Pronabec.Dto.Enums;

namespace Pronabec.UseCases.Instituciones.Commands.UpdateInstitucionCommand
{
    public sealed record UpdateInstitucionCommand : IRequest<InstitucionDto>
    {
        public int Id { get; set; }        
        public string Direccion { get; set; }
        public EstadoDto Estado { get; set; }
    }
}