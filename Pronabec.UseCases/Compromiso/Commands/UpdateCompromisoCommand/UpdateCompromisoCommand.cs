using MediatR;
using Pronabec.Dto;
using Pronabec.Dto.Enums;

namespace Pronabec.UseCases.Compromiso.Commands.UpdateCompromisoCommand
{
    public sealed record UpdateCompromisoCommand : IRequest<CompromisoDto>
    {
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Descripcion { get; set; }
        public EstadoDto Estado { get; set; }
    }
}