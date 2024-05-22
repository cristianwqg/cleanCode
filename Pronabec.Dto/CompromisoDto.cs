using Pronabec.Dto.Enums;
using System;

namespace Pronabec.Dto
{
    public class CompromisoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Descripcion { get; set; }
        public EstadoDto Estado { get; set; }
    }
}