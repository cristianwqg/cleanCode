using MediatR;
using Pronabec.Dto;
using Pronabec.Dto.Enums;
using Pronabec.UseCases.Common.Bases;
using System;

namespace Pronabec.UseCases.Compromiso.Commands.CreateCompromisoCommand
{    
    public record CreateCompromisoCommand : IRequest<BaseResponse<CompromisoDto>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Descripcion { get; set; }
        public EstadoDto Estado { get; set; }
    }
}