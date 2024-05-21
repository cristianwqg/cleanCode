using Pronabec.Dto.Enums;

namespace Pronabec.Dto
{
    public class InstitucionDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public EstadoDto Estado { get; set; }
    }
}