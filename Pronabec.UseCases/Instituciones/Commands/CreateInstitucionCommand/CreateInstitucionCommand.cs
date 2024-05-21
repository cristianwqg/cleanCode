using MediatR;
using Pronabec.Dto;
using Pronabec.Dto.Enums;
using Pronabec.UseCases.Common.Bases;

namespace Pronabec.UseCases.Instituciones.Commands.CreateInstitucionCommand
{    
    public record CreateInstitucionCommand : IRequest<BaseResponse<InstitucionDto>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public EstadoDto Estado { get; set; }
    }
}